using System.Security.Claims;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
    }
} 