using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Settings.Commands.UpdateUserSettings;
using SocialNetwork.Application.Features.Settings.Queries.GetUserSettings;
using SocialNetwork.Application.Features.Settings.Queries.GetPrivacySettings;
using SocialNetwork.Application.Features.Settings.Queries.GetNotifySettings;
using SocialNetwork.Application.Features.Settings.Queries.GetSocialLinks;
using SocialNetwork.Application.Features.Settings.Commands.UpdatePrivacySettings;
using SocialNetwork.Application.Features.Settings.Commands.UpdateNotifySettings;
using SocialNetwork.Application.Features.Settings.Commands.UpdateSocialLinks;
using SocialNetwork.Models.Settings;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new SettingsMasterViewModel
            {
                UserSettings = await _mediator.Send(new GetUserSettingsQuery()),
                SocialLinks = await _mediator.Send(new GetSocialLinksQuery()),
                NotifySettings = await _mediator.Send(new GetNotifySettingsQuery()),
                PrivacySettings = await _mediator.Send(new GetPrivacySettingsQuery())
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(SettingsMasterViewModel model)
        {
            var command = new UpdateUserSettingsCommand
            {
                Name = model.UserSettings.Name ?? string.Empty,
                Bio = model.UserSettings.Bio ?? string.Empty,
                Gender = (int)model.UserSettings.Gender,
                Relationship = (int)model.UserSettings.Relationship
            };
            
            await _mediator.Send(command);
            TempData["SuccessMessage"] = "Профиль успешно обновлен.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSocialLinks(SettingsMasterViewModel model)
        {
            var command = new UpdateSocialLinksCommand
            {
                Facebook = model.SocialLinks.Facebook ?? string.Empty,
                Instagram = model.SocialLinks.Instagram ?? string.Empty,
                Twitter = model.SocialLinks.Twitter ?? string.Empty,
                YouTube = model.SocialLinks.YouTube ?? string.Empty,
                GitHub = model.SocialLinks.GitHub ?? string.Empty
            };
            
            await _mediator.Send(command);
            TempData["SuccessMessage"] = "Социальные сети успешно обновлены.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNotifySettings(SettingsMasterViewModel model)
        {
            var command = new UpdateNotifySettingsCommand
            {
                SendMessage = model.NotifySettings.SendMessage,
                LikedPhoto = model.NotifySettings.LikedPhoto,
                SharedPhoto = model.NotifySettings.SharedPhoto,
                Followed = model.NotifySettings.Followed,
                Mentioned = model.NotifySettings.Mentioned,
                SendRequest = model.NotifySettings.SendRequest
            };
            
            await _mediator.Send(command);
            TempData["SuccessMessage"] = "Настройки уведомлений успешно обновлены.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePrivacySettings(SettingsMasterViewModel model)
        {
            var command = new UpdatePrivacySettingsCommand
            {
                FollowMe = model.PrivacySettings.FollowMe.HasValue ? (int)model.PrivacySettings.FollowMe.Value : 0,
                MessageMe = model.PrivacySettings.MessageMe.HasValue ? (int)model.PrivacySettings.MessageMe.Value : 0,
                Activities = model.PrivacySettings.Activities.HasValue ? (int)model.PrivacySettings.Activities.Value : 0,
                Status = model.PrivacySettings.Status.HasValue ? (int)model.PrivacySettings.Status.Value : 0,
                MyTags = model.PrivacySettings.MyTags.HasValue ? (int)model.PrivacySettings.MyTags.Value : 0,
                SearchEngine = model.PrivacySettings.SearchEngine.HasValue ? (int)model.PrivacySettings.SearchEngine.Value : 0
            };
            
            await _mediator.Send(command);
            TempData["SuccessMessage"] = "Настройки приватности успешно обновлены.";
            return RedirectToAction("Index");
        }
    }
} 