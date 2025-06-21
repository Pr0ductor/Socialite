using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Queries.GetSocialLinks
{
    public class GetSocialLinksQuery : IRequest<SocialLinksDto>
    {
    }
} 