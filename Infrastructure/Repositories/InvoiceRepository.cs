using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Invoice>> GetByReservationIdAsync(int reservationId)
    {
        return await _dbSet
            .Include(i => i.Reservation)
            .Include(i => i.Payments)
            .Where(i => i.ReservationId == reservationId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invoice>> GetByStatusAsync(string status)
    {
        return await _dbSet
            .Include(i => i.Reservation)
            .Include(i => i.Payments)
            .Where(i => i.Status == status)
            .ToListAsync();
    }
}
