using MediatR;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateNotifySettings
{
    public class UpdateNotifySettingsCommand : IRequest<bool>
    {
        public bool SendMessage { get; set; }
        public bool LikedPhoto { get; set; }
        public bool SharedPhoto { get; set; }
        public bool Followed { get; set; }
        public bool Mentioned { get; set; }
        public bool SendRequest { get; set; }
    }
} 