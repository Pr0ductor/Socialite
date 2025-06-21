using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IPageRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
