using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Contexts;

public class PostsConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(
        new Post()
        {
            Id = 1,
            UserPageId = 1,
            Content = "Контент1",
            LikeCount = 1,
            DislikeCount = 1
        },
        new Post()
        {
            Id = 2,
            UserPageId = 1,
            Content = "Контент2",
            LikeCount = 3,
            DislikeCount = 3
        },
        new Post()
        {
            Id = 3,
            UserPageId = 1,
            Content = "Контент3",
            LikeCount = 2,
            DislikeCount = 2
        },
        new Post()
        {
            Id = 4,
            UserPageId = 1,
            Content = "Контент4",
            LikeCount = 4,
            DislikeCount = 4
        },
        new Post()
        {
            Id = 5,
            UserPageId = 1,
            Content = "Контент5",
            LikeCount = 5,
            DislikeCount = 5
        },
        new Post()
        {
            Id = 6,
            UserPageId = 2,
            Content = "Контент2",
            LikeCount = 2,
            DislikeCount = 2
        },
        new Post()
        {
            Id = 7,
            UserPageId = 3,
            Content = "Контент3",
            LikeCount = 3,
            DislikeCount = 3
        }
        );
    }
}
