using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Commands.UpdateUserSettings
{
    public class UpdateUserSettingsCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Gender { get; set; }
        public int Relationship { get; set; }
    }
} 