using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
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
            var userId = _currentUserService.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null) return false;

            var privacy = await _privacyRepository.GetByUserIdAsync(user.UserId);

            if (privacy == null)
            {
                privacy = new Privacy { UserId = user.UserId };
            }

            privacy.FollowMe = (Who)request.FollowMe;
            privacy.MessageMe = (Who)request.MessageMe;
            privacy.Activities = (YesNo)request.Activities;
            privacy.Status = (Status)request.Status;
            privacy.MyTags = (Who)request.MyTags;
            privacy.SearchEngine = (YesNo)request.SearchEngine;

            if (privacy.Id == 0)
                await _privacyRepository.AddAsync(privacy);
            else
                await _privacyRepository.UpdateAsync(privacy);

            return true;
        }
    }
} 