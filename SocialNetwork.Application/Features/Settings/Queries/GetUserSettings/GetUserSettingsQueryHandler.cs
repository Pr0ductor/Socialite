using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Queries.GetUserSettings
{
    public class GetUserSettingsQueryHandler : IRequestHandler<GetUserSettingsQuery, UserSettingsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetUserSettingsQueryHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<UserSettingsDto> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (identityId == null)
            {
                // Or throw an exception, depending on expected behavior
                return new UserSettingsDto(); 
            }
            var user = await _userRepository.GetByIdentityIdAsync(identityId);

            if (user == null)
            {
                return new UserSettingsDto();
            }

            return new UserSettingsDto()
            {
                Name = user.Name,
                Bio = user.Bio,
                Email = user.Email,
                Gender = user.Gender,
                Relationship = user.Relationship
            };
        }
    }
} 