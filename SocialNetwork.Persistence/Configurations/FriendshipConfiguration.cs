using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(f => f.FriendshipId);

            builder.Property(f => f.UserId)
                .IsRequired();

            builder.Property(f => f.FriendId)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired();

            builder.Property(f => f.AddedAt)
                .IsRequired();

            // Настраиваем связи с таблицей AspNetUsers
            builder.HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 