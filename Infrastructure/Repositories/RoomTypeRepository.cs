using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RoomType>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        return await _dbSet
            .Where(r => r.BasePrice >= minPrice && r.BasePrice <= maxPrice)
            .ToListAsync();
    }

    public async Task<RoomType?> GetByTypeNameAsync(string typeName)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.TypeName == typeName);
    }
}
