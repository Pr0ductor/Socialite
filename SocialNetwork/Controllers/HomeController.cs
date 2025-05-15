using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Comments.Query.GetByPostId;
using SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;
using SocialNetwork.Models;
using SocialNetwork.Models.Home;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
        public IActionResult Pages() { return View(); }
        public IActionResult Market() { return View(); }
        public IActionResult Event2() { return View(); }
        public IActionResult Groups2() { return View(); }
        public IActionResult Settings() { return View(); }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
