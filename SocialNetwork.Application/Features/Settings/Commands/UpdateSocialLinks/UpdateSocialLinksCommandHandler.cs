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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return false;

            var socialLink = await _socialLinkRepository.GetByUserIdAsync(user.UserId);

            if (socialLink == null)
            {
                socialLink = new SocialLink { UserId = user.UserId };
            }

            socialLink.Facebook = request.Facebook;
            socialLink.Instagram = request.Instagram;
            socialLink.Twitter = request.Twitter;
            socialLink.YouTube = request.YouTube;
            socialLink.GitHub = request.GitHub;

            if (socialLink.Id == 0)
                await _socialLinkRepository.AddAsync(socialLink);
            else
                await _socialLinkRepository.UpdateAsync(socialLink);

            return true;
        }
    }
} 