using SocialNetwork.Application.Features.Events.Query.GetAll;

namespace SocialNetwork.Models.Events
{
    public class EventVM
    {
        public IEnumerable<GetAllDto> Events { get; set; }
    }
}
