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

public class PrivacyConfiguration : IEntityTypeConfiguration<Privacy>
{
    public void Configure(EntityTypeBuilder<Privacy> builder)
    {
        builder.HasData(

            new Privacy { UserId = 1, FollowMe = Who.Everyone, MessageMe = Who.Everyone, Activities = YesNo.No, Status = Status.Online, MyTags = Who.Nobody, SearchEngine = YesNo.No }

        );
    }
}