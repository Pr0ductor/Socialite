using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Notify : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public bool SendMessage { get; set; }
    public bool LikedPhoto { get; set; }
    public bool SharedPhoto { get; set; }
    public bool Followed { get; set; }
    public bool Mentioned { get; set; }
    public bool SendRequest { get; set; }
}
