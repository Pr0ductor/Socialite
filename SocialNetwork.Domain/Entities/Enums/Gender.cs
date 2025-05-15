using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
    }
}
