using SocialNetwork.Domain.Entities;
using System.Numerics;

namespace SocialNetwork.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
    
    Task<IEnumerable<Comment>> GetAllAsync();
}
