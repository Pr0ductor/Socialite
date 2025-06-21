using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Persistence.Contexts;

public class NotifyConfiguration : IEntityTypeConfiguration<Notify>
{
    public void Configure(EntityTypeBuilder<Notify> builder)
    {
        builder.HasData(

            new Notify { UserId = 1, SendMessage = true, LikedPhoto = false, SharedPhoto = false, Followed = true, Mentioned = false, SendRequest = false }

        );
    }
}