using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

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
