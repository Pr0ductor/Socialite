using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        // Здесь можно добавить специфичные методы для сообщений
    }
} 