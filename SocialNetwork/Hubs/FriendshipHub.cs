using Microsoft.AspNetCore.SignalR;

namespace SocialNetwork.Hubs
{
    public class FriendshipHub : Hub
    {
        public async Task AddToGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task RemoveFromGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
} 