using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Models.Settings
{
    public class SettingsViewModel
    {
        public UserSettingsDto UserSettings { get; set; }
        public SocialLinksDto SocialLinks { get; set; }
        public NotifySettingsDto NotifySettings { get; set; }
        public PrivacySettingsDto PrivacySettings { get; set; }

        public SettingsViewModel()
        {
            UserSettings = new UserSettingsDto();
            SocialLinks = new SocialLinksDto();
            NotifySettings = new NotifySettingsDto();
            PrivacySettings = new PrivacySettingsDto();
        }
    }
} 