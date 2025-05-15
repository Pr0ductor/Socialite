using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Notify> Notify { get; set; }
        public DbSet<Privacy> Privacy { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new EventsConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotifyConfiguration());
            modelBuilder.ApplyConfiguration(new PrivacyConfiguration());
            modelBuilder.ApplyConfiguration(new SocialLinksConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsConfiguration());
        }
    }
}
