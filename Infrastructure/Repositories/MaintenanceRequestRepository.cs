using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Enums;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class MaintenanceRequestRepository : Repository<MaintenanceRequest>, IMaintenanceRequestRepository
{
    public MaintenanceRequestRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<MaintenanceRequest>> GetByRoomIdAsync(int roomId)
    {
        return await _dbSet
            .Include(m => m.Room)
            .Include(m => m.Staff)
            .Where(m => m.RoomId == roomId)
            .ToListAsync();
    }

    public async Task<IEnumerable<MaintenanceRequest>> GetByStatusAsync(MaintenanceStatus status)
    {
        return await _dbSet
            .Include(m => m.Room)
            .Include(m => m.Staff)
            .Where(m => m.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<MaintenanceRequest>> GetByPriorityAsync(MaintenancePriority priority)
    {
        return await _dbSet
            .Include(m => m.Room)
            .Include(m => m.Staff)
            .Where(m => m.Priority == priority)
            .ToListAsync();
    }
}
