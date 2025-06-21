using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Persistence.Contexts;
using System.Threading.Tasks;

namespace SocialNetwork.Persistence.Repositories
{
    public class NotifyRepository : INotifyRepository
    {
        private readonly IGenericRepository<Notify> _repository;
        private readonly ApplicationDbContext _dbContext;

        public NotifyRepository(IGenericRepository<Notify> repository, ApplicationDbContext dbContext)
        {
            _repository=repository;
            _dbContext = dbContext;
        }

        public async Task<Notify?> GetByUserIdAsync(int userId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(n => n.UserId == userId);
        }

        public async Task UpdateAsync(Notify notify)
        {
            await _repository.UpdateAsync(notify);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Notify notify)
        {
            await _repository.AddAsync(notify);
            await _dbContext.SaveChangesAsync();
        }
    }
} 