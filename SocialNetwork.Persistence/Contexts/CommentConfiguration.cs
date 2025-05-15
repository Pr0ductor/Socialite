using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Contexts;

public class CommentsConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(
            new Comment { CommentId = 1, PostId = 1, Name = "Denis", Content = "Очень жду данное мероприятие", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 2, PostId = 1, Name = "Anna", Content = "Будет здорово!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 3, PostId = 1, Name = "Ivan", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 4, PostId = 2, Name = "Olga", Content = "Отличная идея!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 5, PostId = 2, Name = "Sergey", Content = "Не могу дождаться!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 6, PostId = 2, Name = "Maria", Content = "Будет интересно!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 7, PostId = 2, Name = "Alex", Content = "Обязательно приду!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 8, PostId = 2, Name = "Elena", Content = "Супер идея!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 9, PostId = 2, Name = "Dmitry", Content = "Очень интересно!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 10, PostId = 2, Name = "Kate", Content = "Не пропущу!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 11, PostId = 3, Name = "Victor", Content = "Отличное мероприятие!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 12, PostId = 3, Name = "Svetlana", Content = "Будет весело!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 13, PostId = 3, Name = "Igor", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 14, PostId = 3, Name = "Natalia", Content = "Отличная идея!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 15, PostId = 3, Name = "Andrey", Content = "Не могу дождаться!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 16, PostId = 3, Name = "Yulia", Content = "Будет интересно!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 17, PostId = 3, Name = "Boris", Content = "Обязательно приду!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 18, PostId = 3, Name = "Tatyana", Content = "Супер идея!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 19, PostId = 3, Name = "Roman", Content = "Очень интересно!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 20, PostId = 4, Name = "Irina", Content = "Не пропущу!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 21, PostId = 4, Name = "Maxim", Content = "Отличное мероприятие!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 22, PostId = 4, Name = "Lena", Content = "Будет весело!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 23, PostId = 4, Name = "Pavel", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 24, PostId = 4, Name = "Valeria", Content = "Отличная идея!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 25, PostId = 4, Name = "Nikolay", Content = "Не могу дождаться!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 26, PostId = 4, Name = "Ekaterina", Content = "Будет интересно!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 27, PostId = 4, Name = "Vladimir", Content = "Обязательно приду!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 28, PostId = 4, Name = "Alina", Content = "Супер идея!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 29, PostId = 4, Name = "Grigory", Content = "Очень интересно!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 30, PostId = 4, Name = "Polina", Content = "Не пропущу!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 31, PostId = 4, Name = "Evgeny", Content = "Отличное мероприятие!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 32, PostId = 4, Name = "Ksenia", Content = "Будет весело!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 33, PostId = 5, Name = "Anton", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 34, PostId = 5, Name = "Ludmila", Content = "Отличная идея!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 35, PostId = 5, Name = "Kirill", Content = "Не могу дождаться!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 36, PostId = 5, Name = "Marina", Content = "Будет интересно!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 37, PostId = 5, Name = "Gleb", Content = "Обязательно приду!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 38, PostId = 5, Name = "Vera", Content = "Супер идея!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 39, PostId = 5, Name = "Yuri", Content = "Очень интересно!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 40, PostId = 5, Name = "Sofia", Content = "Не пропущу!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 41, PostId = 5, Name = "Ilya", Content = "Отличное мероприятие!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 42, PostId = 5, Name = "Anastasia", Content = "Будет весело!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 43, PostId = 5, Name = "Vasily", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 44, PostId = 5, Name = "Alisa", Content = "Отличная идея!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 45, PostId = 5, Name = "Fedor", Content = "Не могу дождаться!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 46, PostId = 5, Name = "Daria", Content = "Будет интересно!", Img = "/images/avatars/avatar-3.jpg" },
            new Comment { CommentId = 47, PostId = 5, Name = "Mikhail", Content = "Обязательно приду!", Img = "/images/avatars/avatar-4.jpg" },
            new Comment { CommentId = 48, PostId = 5, Name = "Viktoria", Content = "Супер идея!", Img = "/images/avatars/avatar-5.jpg" },
            new Comment { CommentId = 49, PostId = 5, Name = "Timur", Content = "Очень интересно!", Img = "/images/avatars/avatar-6.jpg" },
            new Comment { CommentId = 50, PostId = 5, Name = "Olesya", Content = "Не пропущу!", Img = "/images/avatars/avatar-7.jpg" },
            new Comment { CommentId = 51, PostId = 5, Name = "Stanislav", Content = "Отличное мероприятие!", Img = "/images/avatars/avatar-1.jpg" },
            new Comment { CommentId = 52, PostId = 5, Name = "Milana", Content = "Будет весело!", Img = "/images/avatars/avatar-2.jpg" },
            new Comment { CommentId = 53, PostId = 5, Name = "Artem", Content = "С нетерпением жду!", Img = "/images/avatars/avatar-3.jpg" }


        );
    }
}