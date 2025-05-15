using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Persistence.Contexts;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
        new User()
        {
            UserId = 1,
            Name = "Денис",
            Img = "~/images/avatars/avatar-7.jpg",
            Email = "deniskapipiska@loh.ru",
            Password = "lublumujikov",
            Bio = "Хочу клубничку",
            Gender = Gender.Female,
            Relationship = Relationship.Single,
            TwoFactorAuthentication = Enable.Enable,
        }
        );
    }
}
