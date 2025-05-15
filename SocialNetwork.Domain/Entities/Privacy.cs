using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Privacy : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public Who? FollowMe { get; set; }
    public Who? MessageMe { get; set; }
    public YesNo? Activities { get; set; }
    public Status? Status { get; set; }
    public Who? MyTags { get; set; }
    public YesNo? SearchEngine { get; set; }
}
