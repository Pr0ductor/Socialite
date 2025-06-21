using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Infrastructure.Services;
using SocialNetwork.Infrastructure.Settings;
using SocialNetwork.Persistence.Contexts;
using Microsoft.Extensions.Options;

namespace SocialNetwork.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            //services.AddSmtpSetting(configuration);
            services.AddServices();
            services.AddTransient<IFriendshipService, FriendshipService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<IAuthService, AuthService>()
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>() 
                .AddDefaultTokenProviders();

        }

        //private static void AddSmtpSetting(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var ems = configuration.GetSection("EmailServices");
        //    services.Configure<EmailSettings>((EmailSettings?)ems);
        //}
    }
}
