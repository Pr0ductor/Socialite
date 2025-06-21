using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateNotifySettings
{
    public class UpdateNotifySettingsCommand : IRequest<bool>
    {
        public NotifySettingsDto NotifySettings { get; set; } = new();
    }
} 