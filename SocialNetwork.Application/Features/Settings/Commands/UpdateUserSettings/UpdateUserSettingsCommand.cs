using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateUserSettings
{
    public class UpdateUserSettingsCommand : IRequest<bool>
    {
        public UserSettingsDto UserSettings { get; set; } = new();
    }
} 