using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Application.Features.Settings.Dtos
{
    public class UserSettingsDto
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public Relationship Relationship { get; set; }
    }
} 