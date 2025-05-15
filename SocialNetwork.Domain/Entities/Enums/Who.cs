using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Who
    {
        [Display(Name = "Everyone")]
        Everyone,
        [Display(Name = "People I Follow")]
        PeopleIFollow,
        [Display(Name = "Nobody")]
        Nobody,
    }
}
