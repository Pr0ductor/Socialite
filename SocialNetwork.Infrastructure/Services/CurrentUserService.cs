using Microsoft.AspNetCore.Http;
using SocialNetwork.Application.Interfaces.Services;
using System.Security.Claims;

namespace SocialNetwork.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
    }
} 