using Domain.Models;
using Application.Contracts.Repositories;

namespace Application.Contracts;

public interface IGuestRepository : IRepository<Guest>
{
    Task<IEnumerable<Guest>> GetGuestsWithReservationsAsync();
    Task<Guest?> GetByEmailAsync(string email);
}
