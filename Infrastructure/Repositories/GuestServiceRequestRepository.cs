using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Enums;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class GuestServiceRequestRepository : Repository<GuestServiceRequest>, IGuestServiceRequestRepository
{
    public GuestServiceRequestRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<GuestServiceRequest>> GetByReservationIdAsync(int reservationId)
    {
        return await _dbSet
            .Include(g => g.Reservation)
            .Include(g => g.Service)
            .Where(g => g.ReservationId == reservationId)
            .ToListAsync();
    }

    public async Task<IEnumerable<GuestServiceRequest>> GetByStatusAsync(ServiceRequestStatus status)
    {
        return await _dbSet
            .Include(g => g.Reservation)
            .Include(g => g.Service)
            .Where(g => g.Status == status)
            .ToListAsync();
    }
}
