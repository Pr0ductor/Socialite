using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Persistence.Contexts;
using SocialNetwork.Persistence.Repositories;

namespace SocialNetwork.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IEventRepository, EventRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IPageRepository, PageRepository>()
                .AddTransient<IFriendshipRepository, FriendshipRepository>()
                .AddTransient<IMessageRepository, MessageRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ISocialLinkRepository, SocialLinkRepository>()
                .AddTransient<INotifyRepository, NotifyRepository>()
                .AddTransient<IPrivacyRepository, PrivacyRepository>();
        }
    }
}
