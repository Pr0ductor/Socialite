using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Relationship
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Single")]
        Single,
        [Display(Name = "In a Relationship")]
        InRelationship,
        [Display(Name = "Married")]
        Married,
        [Display(Name = "Engaged")]
        Engaged,

    }
}
