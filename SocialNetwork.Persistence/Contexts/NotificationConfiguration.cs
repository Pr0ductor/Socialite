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

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasData(

            new Notification { UserId = 1, Email = YesNo.Yes, Web = YesNo.No, Phone = YesNo.No }
            
        );
    }
}