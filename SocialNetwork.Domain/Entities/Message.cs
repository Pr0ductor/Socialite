using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Common;

namespace SocialNetwork.Domain.Entities
{
    public class Message : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? ReadAt { get; set; }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public virtual IdentityUser Sender { get; set; }
        public virtual IdentityUser Receiver { get; set; }
    }
} 