
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Enums;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Room>> GetRoomsByStatusAsync(RoomStatus status)
    {
        return await _dbSet
            .Include(r => r.RoomType)
            .Where(r => r.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut)
    {
        var bookedRoomIds = await _context.Reservations
            .Where(r => r.CheckInDate <= checkOut && r.CheckOutDate >= checkIn)
            .Select(r => r.RoomId)
            .ToListAsync();

        return await _dbSet
            .Include(r => r.RoomType)
            .Where(r => !bookedRoomIds.Contains(r.RoomId))
            .ToListAsync();
    }

    public async Task<Room?> GetRoomWithDetailsAsync(int roomId)
    {
        return await _dbSet
            .Include(r => r.RoomType)
            .Include(r => r.Reservations)
            .Include(r => r.MaintenanceRequests)
            .FirstOrDefaultAsync(r => r.RoomId == roomId);
    }
}
