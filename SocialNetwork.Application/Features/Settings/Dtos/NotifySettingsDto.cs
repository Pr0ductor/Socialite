using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Application.Features.Settings.Dtos
{
    public class NotifySettingsDto
    {
        public bool SendMessage { get; set; }
        public bool LikedPhoto { get; set; }
        public bool SharedPhoto { get; set; }
        public bool Followed { get; set; }
        public bool Mentioned { get; set; }
        public bool SendRequest { get; set; }
    }
} 