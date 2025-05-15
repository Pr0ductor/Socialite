using SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;
using SocialNetwork.Application.Features.Comments.Query.GetByPostId;


namespace SocialNetwork.Models.Home
{
    public class HomeVM
    {
        public IEnumerable<GetByUserPageIdDto> Feeds { get; set; }
    }
}
