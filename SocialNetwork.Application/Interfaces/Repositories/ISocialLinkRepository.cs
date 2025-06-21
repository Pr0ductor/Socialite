namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface ISocialLinkRepository
    {
        Task<Domain.Entities.SocialLink?> GetByUserIdAsync(int userId);
        Task UpdateAsync(Domain.Entities.SocialLink socialLink);
        Task AddAsync(Domain.Entities.SocialLink socialLink);
    }
} 