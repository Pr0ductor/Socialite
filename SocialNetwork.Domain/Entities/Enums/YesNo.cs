using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum YesNo
    {
        [Display(Name = "Yes")]
        Yes,
        [Display(Name = "No")]
        No,
    }
}
