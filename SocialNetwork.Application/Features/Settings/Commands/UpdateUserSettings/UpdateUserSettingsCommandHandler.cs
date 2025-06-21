using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities.Enums;
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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return false;

            user.Name = request.Name;
            user.Bio = request.Bio;
            user.Gender = (Gender)request.Gender;
            user.Relationship = (Relationship)request.Relationship;

            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
} 