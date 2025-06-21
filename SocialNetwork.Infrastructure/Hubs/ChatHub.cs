using Microsoft.AspNetCore.SignalR;

namespace SocialNetwork.Infrastructure.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string senderId, string receiverId, string content)
    {
        await Clients.All.SendAsync("ReceiveMessage", senderId, receiverId, content);
    }

    public async Task JoinChat(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userId);
    }

    public async Task LeaveChat(string userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
    }
} 