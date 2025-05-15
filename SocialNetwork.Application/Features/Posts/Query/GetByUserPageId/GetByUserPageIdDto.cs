using SocialNetwork.Application.Features.Comments.Query.GetByPostId;

namespace SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;

public class GetByUserPageIdDto
{
    public int Id { get; set; }

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

    /// <summary>
    /// Комменты
    /// </summary>
    public List<GetByPostIdDto> Comments { get; set; } = default!;
}
