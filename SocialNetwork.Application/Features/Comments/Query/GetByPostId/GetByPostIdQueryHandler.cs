using MediatR;
using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Application.Features.Comments.Query.GetByPostId;

internal class GetByPostIdQueryHandler : IRequestHandler<GetByPostIdQuery, IEnumerable<GetByPostIdDto>>
{
    private readonly ICommentRepository _commentRepository;

    public GetByPostIdQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<GetByPostIdDto>> Handle(GetByPostIdQuery query, CancellationToken cancellationToken)
    {
        var data = await _commentRepository.GetByPostIdAsync(query.postId);

        var result = data.Select(p => new GetByPostIdDto
        {
            CommentId = p.CommentId,
            PostId = p.PostId,
            Name = p.Name,
            Content = p.Content,
            Img = p.Img,
        });

        return result ?? new List<GetByPostIdDto>() { };
    }
}
