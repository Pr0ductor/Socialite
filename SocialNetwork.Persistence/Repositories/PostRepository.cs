using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IGenericRepository<Post> _repository;

        public PostRepository(IGenericRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> GetByUserPageIdAsync(int userPageId)
        {
            return await _repository.Entities
                .Where(x => x.UserPageId == userPageId)
                .ToListAsync();
        }
    }
}
