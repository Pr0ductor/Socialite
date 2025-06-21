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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return false;

            var notify = await _notifyRepository.GetByUserIdAsync(user.UserId);

            if (notify == null)
            {
                notify = new Notify { UserId = user.UserId };
            }

            notify.SendMessage = request.SendMessage;
            notify.LikedPhoto = request.LikedPhoto;
            notify.SharedPhoto = request.SharedPhoto;
            notify.Followed = request.Followed;
            notify.Mentioned = request.Mentioned;
            notify.SendRequest = request.SendRequest;

            if (notify.Id == 0)
                await _notifyRepository.AddAsync(notify);
            else
                await _notifyRepository.UpdateAsync(notify);

            return true;
        }
    }
} 