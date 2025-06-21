using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Persistence.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly IGenericRepository<User> _repository;
        public PageRepository(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}
