using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Auth.Login;
using SocialNetwork.Application.Features.Auth.Register;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Models;
using SocialNetwork.Models.Auth;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new RegisterCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };
            var isSuccess = await _mediator.Send(command);

            if (isSuccess)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError(string.Empty, "A user with this email already exists.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new LoginCommand
            {
                Email = model.Email,
                Password = model.Password,
            };

            var isSuccess = await _mediator.Send(command);
            if (isSuccess)
                 return RedirectToAction("Index", "Home");

            ModelState.AddModelError(string.Empty, "Wrong email or password");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
