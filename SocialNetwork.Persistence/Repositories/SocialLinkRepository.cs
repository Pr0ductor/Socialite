using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Persistence.Contexts;
using System.Threading.Tasks;

namespace SocialNetwork.Persistence.Repositories
{
    public class SocialLinkRepository : ISocialLinkRepository
    {
        private readonly IGenericRepository<SocialLink> _repository;
        private readonly ApplicationDbContext _dbContext;

        public SocialLinkRepository(IGenericRepository<SocialLink> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<SocialLink?> GetByUserIdAsync(int userId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task UpdateAsync(SocialLink socialLink)
        {
            await _repository.UpdateAsync(socialLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(SocialLink socialLink)
        {
            await _repository.AddAsync(socialLink);
            await _dbContext.SaveChangesAsync();
        }
    }
} 