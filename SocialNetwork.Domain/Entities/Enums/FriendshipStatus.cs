using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities.Enums;

public enum FriendshipStatus
{
    [Display(Name = "Pending")]
    Pending,
    [Display(Name = "Accepted")]
    Accepted,
    [Display(Name = "Rejected")]
    Rejected,
    [Display(Name = "Blocked")]
    Blocked
}
