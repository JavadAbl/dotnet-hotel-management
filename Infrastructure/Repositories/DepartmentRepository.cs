using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Department?> GetByNameAsync(string name)
    {
        return await _dbSet
            .Include(d => d.StaffMembers)
            .FirstOrDefaultAsync(d => d.DepartmentName == name);
    }
}
