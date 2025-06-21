using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateNotifySettings
{
    public class UpdateNotifySettingsCommandHandler : IRequestHandler<UpdateNotifySettingsCommand, bool>
    {
        private readonly INotifyRepository _notifyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public UpdateNotifySettingsCommandHandler(INotifyRepository notifyRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _notifyRepository = notifyRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateNotifySettingsCommand request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return false;

            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return false;

            var notify = await _notifyRepository.GetByUserIdAsync(appUser.UserId);

            if (notify == null)
            {
                notify = new Notify { UserId = appUser.UserId };
                UpdateNotifyProperties(notify, request);
                await _notifyRepository.AddAsync(notify);
            }
            else
            {
                UpdateNotifyProperties(notify, request);
                await _notifyRepository.UpdateAsync(notify);
            }

            return true;
        }

        private void UpdateNotifyProperties(Notify notify, UpdateNotifySettingsCommand request)
        {
            notify.SendMessage = request.NotifySettings.SendMessage;
            notify.LikedPhoto = request.NotifySettings.LikedPhoto;
            notify.SharedPhoto = request.NotifySettings.SharedPhoto;
            notify.Followed = request.NotifySettings.Followed;
            notify.Mentioned = request.NotifySettings.Mentioned;
            notify.SendRequest = request.NotifySettings.SendRequest;
        }
    }
} 