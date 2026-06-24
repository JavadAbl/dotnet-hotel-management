
using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IRoomTypeRepository : IRepository<RoomType>
{
    Task<IEnumerable<RoomType>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    Task<RoomType?> GetByTypeNameAsync(string typeName);
}
