using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Status
    {
        [Display(Name = "Online")]
        Online,
        [Display(Name = "Offline")]
        Offline,
    }
}
