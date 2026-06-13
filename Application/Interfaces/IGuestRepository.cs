using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IGuestRepository : IRepository<Guest>
{
    Task<IEnumerable<Guest>> GetGuestsWithReservationsAsync();
    Task<Guest?> GetByEmailAsync(string email);
}
