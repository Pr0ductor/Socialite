using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Persistence.Contexts;
using System.Threading.Tasks;

namespace SocialNetwork.Persistence.Repositories
{
    public class PrivacyRepository : IPrivacyRepository
    {
        private readonly IGenericRepository<Privacy> _repository;
        private readonly ApplicationDbContext _dbContext;

        public PrivacyRepository(IGenericRepository<Privacy> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<Privacy?> GetByUserIdAsync(int userId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task UpdateAsync(Privacy privacy)
        {
            await _repository.UpdateAsync(privacy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Privacy privacy)
        {
            await _repository.AddAsync(privacy);
            await _dbContext.SaveChangesAsync();
        }
    }
} 