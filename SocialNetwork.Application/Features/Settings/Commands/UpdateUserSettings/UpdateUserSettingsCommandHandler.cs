using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateUserSettings
{
    public class UpdateUserSettingsCommandHandler : IRequestHandler<UpdateUserSettingsCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserSettingsCommandHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return false;

            var user = await _userRepository.GetByIdentityIdAsync(identityId);
            if (user == null) return false;

            user.Name = request.UserSettings.Name;
            user.Bio = request.UserSettings.Bio;
            user.Gender = request.UserSettings.Gender;
            user.Relationship = request.UserSettings.Relationship;

            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
} 