using MediatR;
using SocialNetwork.Application.Features.Comments.Query.GetByPostId;
using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Application.Features.Posts.Query.GetByUserPageId;

    internal class GetByUserPageIdQueryHandler : IRequestHandler<GetByUserPageIdQuery, IEnumerable<GetByUserPageIdDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;


        public GetByUserPageIdQueryHandler(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<GetByUserPageIdDto>> Handle(GetByUserPageIdQuery query,
            CancellationToken cancellationToken)
        {
            var data = await _postRepository.GetByUserPageIdAsync(query.UserPageId);

            var postIds = data.Select(p => p.Id).ToList();

            var allComments = await _commentRepository.GetAllAsync();

            var result = data.Select(p => new GetByUserPageIdDto
            {
                Id = p.Id,
                UserPageId = p.UserPageId,
                Content = p.Content,
                DislikeCount = p.DislikeCount,
                LikeCount = p.LikeCount,
                Comments = allComments
                    .Where(c => c.PostId == p.Id)
                    .Select(x => new GetByPostIdDto
                    {
                        CommentId = x.CommentId,
                        PostId = x.PostId,
                        Name = x.Name,
                        Content = x.Content,
                        Img = x.Img
                    })
                    .ToList()
            }).ToList();
            return result;
        }
    }