
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class StaffRepository : Repository<Staff>, IStaffRepository
{
    public StaffRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Staff>> GetByDepartmentAsync(int departmentId)
    {
        return await _dbSet
            .Include(s => s.Department)
            .Where(s => s.DepartmentId == departmentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Staff>> GetByRoleAsync(string role)
    {
        return await _dbSet
            .Include(s => s.Department)
            .Where(s => s.Role == role)
            .ToListAsync();
    }
}
