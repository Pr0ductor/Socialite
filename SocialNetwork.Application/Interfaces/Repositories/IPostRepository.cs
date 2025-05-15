using SocialNetwork.Domain.Entities;
using System.Numerics;

namespace SocialNetwork.Application.Interfaces.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetByUserPageIdAsync(int userPageId);
}
