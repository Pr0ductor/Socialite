namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface INotifyRepository
    {
        Task<Domain.Entities.Notify?> GetByUserIdAsync(int userId);
        Task UpdateAsync(Domain.Entities.Notify notify);
        Task AddAsync(Domain.Entities.Notify notify);
    }
} 