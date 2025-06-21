using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Application.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Hubs;
using SocialNetwork.Application.Interfaces.Repositories;

using SocialNetwork.Persistence.Repositories;

using SocialNetwork.Persistence.Contexts;
using SocialNetwork.Application.ViewModels.Messages;

namespace SocialNetwork.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMessageRepository _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageService(ApplicationDbContext context, UserManager<IdentityUser> userManager, IMessageRepository messageRepository, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _messageRepository = messageRepository;
            _hubContext = hubContext;
        }

        public async Task<List<FriendViewModel>> GetUserFriendsWithLastMessageAsync(string userId)
        {
            var friends = await _context.Friendships
                .Where(f => (f.UserId == userId || f.FriendId == userId) && f.Status == Domain.Entities.Enums.FriendshipStatus.Accepted)
                .Select(f => f.UserId == userId ? f.FriendId : f.UserId)
                .ToListAsync();

            var friendViewModels = new List<FriendViewModel>();

            foreach (var friendId in friends)
            {
                var friend = await _userManager.FindByIdAsync(friendId);
                if (friend == null) continue;

                var lastMessage = await _context.Messages
                    .Where(m => (m.SenderId == userId && m.ReceiverId == friendId) ||
                               (m.SenderId == friendId && m.ReceiverId == userId))
                    .OrderByDescending(m => m.SentAt)
                    .FirstOrDefaultAsync();

                var unreadCount = await GetUnreadMessagesCountAsync(userId, friendId);

                friendViewModels.Add(new FriendViewModel
                {
                    Id = friend.Id,
                    Name = friend.UserName,
                    ImageUrl = "/images/avatars/avatar-1.jpg", // Заглушка, нужно будет добавить реальные аватары
                    IsOnline = true, // Заглушка, нужно будет добавить реальный онлайн статус
                    LastMessage = lastMessage?.Content,
                    LastMessageTime = lastMessage?.SentAt,
                    UnreadCount = unreadCount
                });
            }

            return friendViewModels;
        }

        public async Task<List<MessageViewModel>> GetChatMessagesAsync(string userId, string friendId)
        {
            var messages = await _context.Messages
                .Where(m => (m.SenderId == userId && m.ReceiverId == friendId) ||
                           (m.SenderId == friendId && m.ReceiverId == userId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            var messageViewModels = new List<MessageViewModel>();

            foreach (var message in messages)
            {
                var sender = await _userManager.FindByIdAsync(message.SenderId);
                if (sender == null) continue;

                messageViewModels.Add(new MessageViewModel
                {
                    Id = message.Id,
                    SenderId = message.SenderId,
                    SenderName = sender.UserName,
                    SenderAvatar = "/images/avatars/avatar-1.jpg", // Заглушка
                    Content = message.Content,
                    SentAt = message.SentAt,
                    IsRead = message.IsRead,
                    IsMine = message.SenderId == userId
                });
            }

            return messageViewModels;
        }

        public async Task<Message> SendMessageAsync(string senderId, string receiverId, string content)
        {
            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            await _messageRepository.AddAsync(message);
            await _context.SaveChangesAsync();

            // Отправляем сообщение через SignalR
            await _hubContext.Clients.Group(receiverId).SendAsync("ReceiveMessage", senderId, receiverId, content);

            return message;
        }

        public async Task MarkMessagesAsReadAsync(string userId, string friendId)
        {
            var unreadMessages = await _context.Messages
                .Where(m => m.SenderId == friendId && m.ReceiverId == userId && !m.IsRead)
                .ToListAsync();

            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
                message.ReadAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetUnreadMessagesCountAsync(string userId, string friendId)
        {
            return await _context.Messages
                .CountAsync(m => m.SenderId == friendId && m.ReceiverId == userId && !m.IsRead);
        }

        public async Task<List<MessageViewModel>> GetNewMessagesAsync(string userId, string friendId, int lastMessageId)
        {
            var messages = await _context.Messages
                .Where(m => ((m.SenderId == userId && m.ReceiverId == friendId) ||
                            (m.SenderId == friendId && m.ReceiverId == userId)) &&
                            m.Id > lastMessageId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            var messageViewModels = new List<MessageViewModel>();

            foreach (var message in messages)
            {
                var sender = await _userManager.FindByIdAsync(message.SenderId);
                if (sender == null) continue;

                messageViewModels.Add(new MessageViewModel
                {
                    Id = message.Id,
                    SenderId = message.SenderId,
                    SenderName = sender.UserName,
                    SenderAvatar = "/images/avatars/avatar-1.jpg", // Заглушка
                    Content = message.Content,
                    SentAt = message.SentAt,
                    IsRead = message.IsRead,
                    IsMine = message.SenderId == userId
                });
            }

            // Помечаем новые сообщения как прочитанные
            if (messages.Any())
            {
                await MarkMessagesAsReadAsync(userId, friendId);
            }

            return messageViewModels;
        }
    }
} 