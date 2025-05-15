using SocialNetwork.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Comment : BaseAuditableEntity
{
    [Key]
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Img { get; set; }
}
