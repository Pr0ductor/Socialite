using MediatR;
using SocialNetwork.Application.Features.Events.Query.GetAll;
using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Application.Features.Events.Query.GetAll;

internal class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GetAllDto>>
{
    private readonly IEventRepository _eventRepository;

    public GetAllQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<GetAllDto>> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        var data = await _eventRepository.GetAllAsync(query.startDate, query.endDate);

        var result = data.Select(e => new GetAllDto
        {
            EventId = e.EventId,
            Name = e.Name,
            Img = e.Img,
            Date = e.Date,
            Author = e.Author,
            IntrestedCount = e.IntrestedCount,
            GoingCount = e.GoingCount,
        });

        return result ?? new List<GetAllDto>() { };
    }
}
