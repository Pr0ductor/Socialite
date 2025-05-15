using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Interfaces.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<IEnumerable<Event>> GetAllAsync(DateOnly? startDate = null, DateOnly? endDate = null);
}
