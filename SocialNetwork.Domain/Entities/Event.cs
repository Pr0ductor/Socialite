using SocialNetwork.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities;

public class Event : BaseAuditableEntity
{
    [Key]
    public int EventId {  get; set; }
    public string? Name { get; set; }
    public string? Img { get; set; }
    public DateOnly? Date { get; set; }
    public string? Author { get; set; }
    public int IntrestedCount { get; set; }
    public int GoingCount { get; set; }
}
