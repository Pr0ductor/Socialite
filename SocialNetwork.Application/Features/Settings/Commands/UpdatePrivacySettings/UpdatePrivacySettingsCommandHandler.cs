using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdatePrivacySettings
{
    public class UpdatePrivacySettingsCommandHandler : IRequestHandler<UpdatePrivacySettingsCommand, bool>
    {
        private readonly IPrivacyRepository _privacyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public UpdatePrivacySettingsCommandHandler(IPrivacyRepository privacyRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _privacyRepository = privacyRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdatePrivacySettingsCommand request, CancellationToken cancellationToken)
        {
            var identityId = _currentUserService.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (identityId == null) return false;

            var appUser = await _userRepository.GetByIdentityIdAsync(identityId);
            if (appUser == null) return false;

            var privacy = await _privacyRepository.GetByUserIdAsync(appUser.UserId);

            if (privacy == null)
            {
                privacy = new Privacy { UserId = appUser.UserId };
                UpdatePrivacyProperties(privacy, request);
                await _privacyRepository.AddAsync(privacy);
            }
            else
            {
                UpdatePrivacyProperties(privacy, request);
                await _privacyRepository.UpdateAsync(privacy);
            }

            return true;
        }

        private void UpdatePrivacyProperties(Privacy privacy, UpdatePrivacySettingsCommand request)
        {
            privacy.FollowMe = request.PrivacySettings.FollowMe;
            privacy.MessageMe = request.PrivacySettings.MessageMe;
            privacy.Activities = request.PrivacySettings.Activities;
            privacy.Status = request.PrivacySettings.Status;
            privacy.MyTags = request.PrivacySettings.MyTags;
            privacy.SearchEngine = request.PrivacySettings.SearchEngine;
        }
    }
} 