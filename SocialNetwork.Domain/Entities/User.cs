using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class User : BaseAuditableEntity
{
    [Key]
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Img { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; }
    public Relationship Relationship { get; set; } 
    public Enable TwoFactorAuthentication { get; set; }
}
