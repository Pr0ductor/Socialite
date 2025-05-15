using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public YesNo? Email { get; set; }
    public YesNo? Web { get; set; }
    public YesNo? Phone { get; set; }
}
