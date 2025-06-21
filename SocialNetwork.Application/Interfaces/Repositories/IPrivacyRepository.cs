namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IPrivacyRepository
    {
        Task<Domain.Entities.Privacy?> GetByUserIdAsync(int userId);
        Task UpdateAsync(Domain.Entities.Privacy privacy);
        Task AddAsync(Domain.Entities.Privacy privacy);
    }
} 