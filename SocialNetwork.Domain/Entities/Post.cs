using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Post : BaseAuditableEntity
{
    /// <summary>
    /// У кого из пользователей этот пост
    /// </summary>

    public int UserPageId { get; set; }

    /// <summary>
    /// Сам контент поста
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Количество лайков
    /// </summary>
    public int LikeCount { get; set; }

    /// <summary>
    /// Количество дизлайков
    /// </summary>
    public int DislikeCount { get; set; }
}
