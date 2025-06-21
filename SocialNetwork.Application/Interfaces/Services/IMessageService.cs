using SocialNetwork.Application.ViewModels.Messages;
using SocialNetwork.Domain.Entities;


namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IMessageService
    {
        Task<List<FriendViewModel>> GetUserFriendsWithLastMessageAsync(string userId);
        Task<List<MessageViewModel>> GetChatMessagesAsync(string userId, string friendId);
        Task<Message> SendMessageAsync(string senderId, string receiverId, string content);
        Task MarkMessagesAsReadAsync(string userId, string friendId);
        Task<int> GetUnreadMessagesCountAsync(string userId, string friendId);
        Task<List<MessageViewModel>> GetNewMessagesAsync(string userId, string friendId, int lastMessageId);
    }
} 