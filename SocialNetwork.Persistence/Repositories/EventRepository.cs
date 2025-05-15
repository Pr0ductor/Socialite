using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Repositories;

public class EventRepository : IEventRepository
{
    private readonly IGenericRepository<Event> _repository;

    public EventRepository(IGenericRepository<Event> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        var today = new DateOnly(2025, 4, 30);

        return await _repository.Entities
            .Where(e => e.Date >= today)  
            .ToListAsync();

    }

    public async Task<IEnumerable<Event>> GetAllAsync(DateOnly? startDate = null, DateOnly? endDate = null)
    {
        var query = _repository.Entities.AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(e => e.Date >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(e => e.Date <= endDate.Value);
        }

        return await query.ToListAsync();
    }
}

