
using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IStaffRepository : IRepository<Staff>
{
    Task<IEnumerable<Staff>> GetByDepartmentAsync(int departmentId);
    Task<IEnumerable<Staff>> GetByRoleAsync(string role);
}
