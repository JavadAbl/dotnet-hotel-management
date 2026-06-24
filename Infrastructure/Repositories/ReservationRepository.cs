using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class ReservationRepository : Repository<Reservation>, IReservationRepository
{
    public ReservationRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(r => r.Guest)
            .Include(r => r.Room)
            .Where(r => r.CheckInDate <= endDate && r.CheckOutDate >= startDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByGuestIdAsync(int guestId)
    {
        return await _dbSet
            .Include(r => r.Guest)
            .Include(r => r.Room)
            .Where(r => r.GuestId == guestId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut)
    {
        return await _dbSet
            .Include(r => r.Room)
            .ThenInclude(r => r.RoomType)
            .Where(r => r.CheckInDate <= checkOut && r.CheckOutDate >= checkIn)
            .ToListAsync();
    }
}
