using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Notify : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public YesNo? SendMessage { get; set; }
    public YesNo? LikedPhoto { get; set; }
    public YesNo? SharedPhoto { get; set; }
    public YesNo? Followed { get; set; }
    public YesNo? Mentioned { get; set; }
    public YesNo? SendRequest { get; set; }
}
