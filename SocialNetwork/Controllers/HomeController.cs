using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Comments.Query.GetByPostId;
using SocialNetwork.Application.Features.Pages.Query.GetAllPages;
using SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Models;
using SocialNetwork.Models.Home;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IFriendshipService _friendshipService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            IMediator mediator,
            IFriendshipService friendshipService,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _mediator = mediator;
            _friendshipService = friendshipService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userPageId = 1;
            var query = new GetByUserPageIdQuery(userPageId);
            var query2 = new GetByPostIdQuery(query.UserPageId);

            var viewModel = new HomeVM
            {
                Feeds = await _mediator.Send(query),
            };
            return View(viewModel);
        }

        public IActionResult Messages() { return View(); }
        public IActionResult Event() { return View(); }
        public IActionResult Groups() { return View(); }
        public async Task<IActionResult> Pages() 
        {
            var query = new GetAllPagesQuery();
            var viewModel = new PageVM
            {
                Pages = await _mediator.Send(query),
            };
            return View(viewModel); 
        }
        public IActionResult Market() { return View(); }
        public IActionResult Event2() { return View(); }
        public IActionResult Groups2() { return View(); }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleFriendRequest(string targetUserId, string action)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                _logger.LogWarning("HandleFriendRequest: Current user not found");
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(targetUserId))
            {
                _logger.LogWarning("HandleFriendRequest: targetUserId is null or empty");
                TempData["Error"] = "Не указан пользователь для действия";
                return RedirectToAction(nameof(Pages));
            }

            if (string.IsNullOrEmpty(action))
            {
                _logger.LogWarning("HandleFriendRequest: action is null or empty");
                TempData["Error"] = "Не указано действие";
                return RedirectToAction(nameof(Pages));
            }

            _logger.LogInformation(
                "HandleFriendRequest: Attempting {Action} friendship. CurrentUser: {CurrentUserId}, TargetUser: {TargetUserId}",
                action, currentUser.Id, targetUserId);

            bool success = false;
            try
            {
                switch (action.ToLower())
                {
                    case "send":
                        success = await _friendshipService.SendFriendRequestAsync(currentUser.Id, targetUserId);
                        break;
                    case "accept":
                        success = await _friendshipService.AcceptFriendRequestAsync(currentUser.Id, targetUserId);
                        break;
                    case "reject":
                        success = await _friendshipService.RejectFriendRequestAsync(currentUser.Id, targetUserId);
                        break;
                    case "remove":
                        success = await _friendshipService.RemoveFriendAsync(currentUser.Id, targetUserId);
                        break;
                    default:
                        _logger.LogWarning("HandleFriendRequest: Unknown action: {Action}", action);
                        TempData["Error"] = "Неизвестное действие";
                        return RedirectToAction(nameof(Pages));
                }

                if (!success)
                {
                    _logger.LogWarning(
                        "HandleFriendRequest: Action {Action} failed. CurrentUser: {CurrentUserId}, TargetUser: {TargetUserId}",
                        action, currentUser.Id, targetUserId);
                    //TempData["Error"] = GetErrorMessage(action);
                }
                else
                {
                    _logger.LogInformation(
                        "HandleFriendRequest: Action {Action} succeeded. CurrentUser: {CurrentUserId}, TargetUser: {TargetUserId}",
                        action, currentUser.Id, targetUserId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, 
                    "HandleFriendRequest: Exception during {Action}. CurrentUser: {CurrentUserId}, TargetUser: {TargetUserId}",
                    action, currentUser.Id, targetUserId);
                TempData["Error"] = "Произошла ошибка при выполнении действия";
            }

            return RedirectToAction(nameof(Pages));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
