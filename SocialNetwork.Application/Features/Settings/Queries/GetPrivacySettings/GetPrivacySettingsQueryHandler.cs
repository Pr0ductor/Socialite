using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Queries.GetPrivacySettings
{
    public class GetPrivacySettingsQueryHandler : IRequestHandler<GetPrivacySettingsQuery, PrivacySettingsDto>
    {
        private readonly IPrivacyRepository _privacyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public GetPrivacySettingsQueryHandler(IPrivacyRepository privacyRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _privacyRepository = privacyRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<PrivacySettingsDto> Handle(GetPrivacySettingsQuery request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return new PrivacySettingsDto();

            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return new PrivacySettingsDto();

            var privacySettings = await _privacyRepository.GetByUserIdAsync(appUser.UserId);

            if (privacySettings == null)
            {
                return new PrivacySettingsDto();
            }

            return new PrivacySettingsDto
            {
                FollowMe = privacySettings.FollowMe,
                MessageMe = privacySettings.MessageMe,
                Activities = privacySettings.Activities,
                Status = privacySettings.Status,
                MyTags = privacySettings.MyTags,
                SearchEngine = privacySettings.SearchEngine
            };
        }
    }
} 