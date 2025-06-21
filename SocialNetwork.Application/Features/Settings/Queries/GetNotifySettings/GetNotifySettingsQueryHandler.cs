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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return new NotifySettingsDto();

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return new NotifySettingsDto();

            var notify = await _notifyRepository.GetByUserIdAsync(user.UserId);
            if (notify == null) return new NotifySettingsDto();

            return new NotifySettingsDto
            {
                SendMessage = notify.SendMessage,
                LikedPhoto = notify.LikedPhoto,
                SharedPhoto = notify.SharedPhoto,
                Followed = notify.Followed,
                Mentioned = notify.Mentioned,
                SendRequest = notify.SendRequest
            };
        }
    }
} 