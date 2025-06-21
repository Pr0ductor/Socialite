using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Persistence.Contexts;

namespace SocialNetwork.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _repository;
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(IGenericRepository<User> repository, ApplicationDbContext dbContext)
    {
        _repository = repository;
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdentityIdAsync(string identityId)
    {
        return await _repository.Entities.FirstOrDefaultAsync(u => u.IdentityId == identityId);
    }

    public async Task UpdateAsync(User user)
    {
        await _repository.UpdateAsync(user);
        await _dbContext.SaveChangesAsync();
    }
} 