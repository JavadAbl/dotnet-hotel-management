using Domain.Models;
using Application.Contracts.Repositories;

namespace Application.Contracts;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department?> GetByNameAsync(string name);
}
