using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Application.Features.Settings.Dtos
{
    public class PrivacySettingsDto
    {
        public Who? FollowMe { get; set; }
        public Who? MessageMe { get; set; }
        public YesNo? Activities { get; set; }
        public Status? Status { get; set; }
        public Who? MyTags { get; set; }
        public YesNo? SearchEngine { get; set; }
    }
} 