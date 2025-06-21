using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Friendship : BaseAuditableEntity
{
    [Key]
    public int FriendshipId { get; set; }

    public string UserId { get; set; }         // IdentityUser.Id
    public string FriendId { get; set; }       // IdentityUser.Id другого пользователя

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
}
