using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdatePrivacySettings
{
    public class UpdatePrivacySettingsCommand : IRequest<bool>
    {
        public PrivacySettingsDto PrivacySettings { get; set; } = new();
    }
} 