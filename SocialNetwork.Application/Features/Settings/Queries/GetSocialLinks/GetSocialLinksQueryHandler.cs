using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Queries.GetSocialLinks
{
    public class GetSocialLinksQueryHandler : IRequestHandler<GetSocialLinksQuery, SocialLinksDto>
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;


        public GetSocialLinksQueryHandler(ISocialLinkRepository socialLinkRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _socialLinkRepository = socialLinkRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<SocialLinksDto> Handle(GetSocialLinksQuery request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return new SocialLinksDto();

            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return new SocialLinksDto();

            var socialLink = await _socialLinkRepository.GetByUserIdAsync(appUser.UserId);

            if (socialLink == null)
            {
                return new SocialLinksDto();
            }

            return new SocialLinksDto
            {
                Facebook = socialLink.Facebook,
                Instagram = socialLink.Instagram,
                Twitter = socialLink.Twitter,
                YouTube = socialLink.YouTube,
                GitHub = socialLink.GitHub
            };
        }
    }
} 