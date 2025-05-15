using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Events.Query.GetAll;

public class GetAllDto
{
    public int EventId { get; set; }
    public string? Name { get; set; }
    public string? Img { get; set; }
    public DateOnly? Date { get; set; }
    public string? Author { get; set; }
    public int IntrestedCount { get; set; }
    public int GoingCount { get; set; }
}
