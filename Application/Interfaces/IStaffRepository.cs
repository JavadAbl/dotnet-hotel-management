using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IStaffRepository : IRepository<Staff>
{
    Task<IEnumerable<Staff>> GetByDepartmentAsync(int departmentId);
    Task<IEnumerable<Staff>> GetByRoleAsync(string role);
}
