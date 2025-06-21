using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.ViewModels.Messages;
using SocialNetwork.Hubs;
using SocialNetwork.Infrastructure.Hubs;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAntiforgery _antiforgery;
        private readonly IHubContext<ChatHub> _chatHub;

        public MessagesController(
            IMessageService messageService,
            UserManager<IdentityUser> userManager,
            IAntiforgery antiforgery,
            IHubContext<ChatHub> chatHub)
        {
            _messageService = messageService;
            _userManager = userManager;
            _antiforgery = antiforgery;
            _chatHub = chatHub;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions { HttpOnly = false });

            var friends = await _messageService.GetUserFriendsWithLastMessageAsync(currentUser.Id);
            var model = new MessagesViewModel
            {
                Friends = friends,
                CurrentUserId = currentUser.Id
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetChatMessages(string friendId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var messages = await _messageService.GetChatMessagesAsync(currentUser.Id, friendId);
            await _messageService.MarkMessagesAsReadAsync(currentUser.Id, friendId);
            
            // Уведомляем через SignalR о прочтении сообщений
            await _chatHub.Clients.Group(friendId).SendAsync("MessagesRead", currentUser.Id);

            return Json(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ReceiverId) || string.IsNullOrWhiteSpace(request.Content))
            {
                return BadRequest("Неверный формат запроса");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            try
            {
                var message = await _messageService.SendMessageAsync(currentUser.Id, request.ReceiverId, request.Content);
                
                // Отправляем сообщение через SignalR получателю
                await _chatHub.Clients.Group(request.ReceiverId).SendAsync("ReceiveMessage", currentUser.Id, request.ReceiverId, message);
                
                return Json(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Произошла ошибка при отправке сообщения: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFriends()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var friends = await _messageService.GetUserFriendsWithLastMessageAsync(currentUser.Id);
            return Json(friends);
        }

        [HttpGet]
        public async Task<IActionResult> GetNewMessages(string friendId, int lastMessageId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var newMessages = await _messageService.GetNewMessagesAsync(currentUser.Id, friendId, lastMessageId);
            return Json(newMessages);
        }

        public class SendMessageRequest
        {
            public string ReceiverId { get; set; }
            public string Content { get; set; }
        }
    }
} 