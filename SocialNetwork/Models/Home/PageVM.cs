using SocialNetwork.Application.Features.Pages.Query.GetAllPages;


namespace SocialNetwork.Models.Home
{
    public class PageVM
    {
        public IEnumerable<GetAllPagesDto> Pages { get; set; }
    }
}
