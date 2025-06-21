using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateSocialLinks
{
    public class UpdateSocialLinksCommandHandler : IRequestHandler<UpdateSocialLinksCommand, bool>
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public UpdateSocialLinksCommandHandler(ISocialLinkRepository socialLinkRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _socialLinkRepository = socialLinkRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateSocialLinksCommand request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return false;

            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return false;

            var socialLink = await _socialLinkRepository.GetByUserIdAsync(appUser.UserId);

            if (socialLink == null)
            {
                socialLink = new SocialLink { UserId = appUser.UserId };
                UpdateSocialLinkProperties(socialLink, request);
                await _socialLinkRepository.AddAsync(socialLink);
            }
            else
            {
                UpdateSocialLinkProperties(socialLink, request);
                await _socialLinkRepository.UpdateAsync(socialLink);
            }

            return true;
        }

        private void UpdateSocialLinkProperties(SocialLink socialLink, UpdateSocialLinksCommand request)
        {
            socialLink.Facebook = request.SocialLinks.Facebook;
            socialLink.Instagram = request.SocialLinks.Instagram;
            socialLink.Twitter = request.SocialLinks.Twitter;
            socialLink.YouTube = request.SocialLinks.YouTube;
            socialLink.GitHub = request.SocialLinks.GitHub;
        }
    }
} 