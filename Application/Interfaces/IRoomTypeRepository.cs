using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoomTypeRepository : IRepository<RoomType>
{
    Task<IEnumerable<RoomType>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    Task<RoomType?> GetByTypeNameAsync(string typeName);
}
