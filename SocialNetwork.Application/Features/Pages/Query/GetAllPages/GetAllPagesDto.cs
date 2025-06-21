using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Pages.Query.GetAllPages
{
    public class GetAllPagesDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Img { get; set; }
        public string Bio { get; set; }
        public Gender Gender { get; set; }
        public Relationship Relationship { get; set; }
        public Enable TwoFactorAuthentication { get; set; }
        public FriendshipStatus? FriendshipStatus { get; set; }
        public string IdentityId { get; set; }
        public bool IsOutgoingRequest { get; set; }
    }
}
