using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class ServiceRepository : Repository<Service>, IServiceRepository
{
    public ServiceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        return await _dbSet
            .Where(s => s.UnitPrice >= minPrice && s.UnitPrice <= maxPrice)
            .ToListAsync();
    }
}
