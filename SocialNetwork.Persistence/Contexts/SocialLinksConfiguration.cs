using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Persistence.Contexts;

public class SocialLinksConfiguration : IEntityTypeConfiguration<SocialLink>
{
    public void Configure(EntityTypeBuilder<SocialLink> builder)
    {
        builder.HasData(
        new SocialLink()
        {
            UserId = 1,
            Facebook = "facebook",
            Instagram = "instagram",
            Twitter = "twitter",
            Youtube = "youtube",
            Github = "github",
        }
        );
    }
}
