using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentRepository(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
        {
            return await _repository.Entities
                .Where(x => x.PostId == postId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}
