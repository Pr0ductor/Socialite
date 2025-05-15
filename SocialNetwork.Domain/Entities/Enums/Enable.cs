using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Enable
    {
        [Display(Name = "Enable")]
        Enable,
        [Display(Name = "Disable")]
        Disable,
    }
}