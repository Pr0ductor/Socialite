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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return new PrivacySettingsDto();

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return new PrivacySettingsDto();

            var privacy = await _privacyRepository.GetByUserIdAsync(user.UserId);
            if (privacy == null) return new PrivacySettingsDto();

            return new PrivacySettingsDto
            {
                FollowMe = privacy.FollowMe,
                MessageMe = privacy.MessageMe,
                Activities = privacy.Activities,
                Status = privacy.Status,
                MyTags = privacy.MyTags,
                SearchEngine = privacy.SearchEngine
            };
        }
    }
} 