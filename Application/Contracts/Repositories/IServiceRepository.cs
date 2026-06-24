
using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IServiceRepository : IRepository<Service>
{
    Task<IEnumerable<Service>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
}
