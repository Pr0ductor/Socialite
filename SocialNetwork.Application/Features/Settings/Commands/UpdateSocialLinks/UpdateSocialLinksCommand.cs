using MediatR;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateSocialLinks
{
    public class UpdateSocialLinksCommand : IRequest<bool>
    {
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string YouTube { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
    }
} 