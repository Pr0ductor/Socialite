using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.ViewModels.Messages
{
    
        public class MessagesViewModel
        {
            public List<FriendViewModel> Friends { get; set; } = new();
            public string CurrentUserId { get; set; }
        }
    
}
