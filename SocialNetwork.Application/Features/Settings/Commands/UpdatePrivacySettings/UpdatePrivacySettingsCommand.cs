using MediatR;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdatePrivacySettings
{
    public class UpdatePrivacySettingsCommand : IRequest<bool>
    {
        public int FollowMe { get; set; }
        public int MessageMe { get; set; }
        public int Activities { get; set; }
        public int Status { get; set; }
        public int MyTags { get; set; }
        public int SearchEngine { get; set; }
    }
} 