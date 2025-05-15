using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class SocialLink : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }
    public string? Youtube { get; set; }
    public string? Github { get; set; }
}
