
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Application.Contracts;
using Domain.Models;

namespace Infrastructure.Repositories;

public class GuestRepository : Repository<Guest>, IGuestRepository
{
    public GuestRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Guest>> GetGuestsWithReservationsAsync()
    {
        return await _dbSet
            .Include(g => g.Reservations)
            .ThenInclude(r => r.Room)
            .ToListAsync();
    }

    public async Task<Guest?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(g => g.Email == email);
    }
}
