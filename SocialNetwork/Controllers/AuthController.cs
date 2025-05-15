using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Comments.Query.GetByPostId;
using SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;
using SocialNetwork.Models;
using SocialNetwork.Models.Home;

namespace SocialNetwork.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
