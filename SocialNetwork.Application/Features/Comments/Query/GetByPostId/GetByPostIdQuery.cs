using MediatR;

namespace SocialNetwork.Application.Features.Comments.Query.GetByPostId;

public record GetByPostIdQuery(int postId) : IRequest<IEnumerable<GetByPostIdDto>>;
