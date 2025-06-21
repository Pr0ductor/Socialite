using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Queries.GetNotifySettings
{
    public class GetNotifySettingsQueryHandler : IRequestHandler<GetNotifySettingsQuery, NotifySettingsDto>
    {
        private readonly INotifyRepository _notifyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public GetNotifySettingsQueryHandler(INotifyRepository notifyRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _notifyRepository = notifyRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<NotifySettingsDto> Handle(GetNotifySettingsQuery request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return new NotifySettingsDto();
            
            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return new NotifySettingsDto();

            var notifySettings = await _notifyRepository.GetByUserIdAsync(appUser.UserId);

            if (notifySettings == null)
            {
                return new NotifySettingsDto();
            }

            return new NotifySettingsDto
            {
                SendMessage = notifySettings.SendMessage,
                LikedPhoto = notifySettings.LikedPhoto,
                SharedPhoto = notifySettings.SharedPhoto,
                Followed = notifySettings.Followed,
                Mentioned = notifySettings.Mentioned,
                SendRequest = notifySettings.SendRequest
            };
        }
    }
} 