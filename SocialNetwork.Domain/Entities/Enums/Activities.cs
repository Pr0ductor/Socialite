using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Activities
    {
        [Display(Name = "Public")]
        Public,
        [Display(Name = "Hide")]
        Hide,
    }
}
