using MediatR;
using SocialNetwork.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handle(LoginCommand command, CancellationToken cancellationToken) =>
        await _authService.LoginAsync(command.Email, command.Password);
}
