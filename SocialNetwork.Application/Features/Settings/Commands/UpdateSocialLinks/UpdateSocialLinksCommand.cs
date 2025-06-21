using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateSocialLinks
{
    public class UpdateSocialLinksCommand : IRequest<bool>
    {
        public SocialLinksDto SocialLinks { get; set; } = new();
    }
} 