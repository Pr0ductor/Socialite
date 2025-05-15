using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Comments.Query.GetByPostId;

public class GetByPostIdDto
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Img { get; set; }
}
