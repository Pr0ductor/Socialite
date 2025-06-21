using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdentityIdAsync(string identityId);
    Task UpdateAsync(User user);
} 