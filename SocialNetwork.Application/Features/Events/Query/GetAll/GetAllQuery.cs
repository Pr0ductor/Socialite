using MediatR;

namespace SocialNetwork.Application.Features.Events.Query.GetAll;

public record GetAllQuery(DateOnly? startDate = null, DateOnly? endDate = null) : IRequest<IEnumerable<GetAllDto>>;
