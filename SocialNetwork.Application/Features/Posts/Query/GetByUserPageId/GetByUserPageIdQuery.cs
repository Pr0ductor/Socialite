using MediatR;

namespace SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;

public record GetByUserPageIdQuery(int UserPageId) : IRequest<IEnumerable<GetByUserPageIdDto>>;
