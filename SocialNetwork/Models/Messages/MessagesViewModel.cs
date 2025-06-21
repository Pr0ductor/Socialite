namespace SocialNetwork.Models.Messages
{
    public class MessagesViewModel
    {
        public List<FriendViewModel> Friends { get; set; } = new();
        public string CurrentUserId { get; set; }
    }
} 