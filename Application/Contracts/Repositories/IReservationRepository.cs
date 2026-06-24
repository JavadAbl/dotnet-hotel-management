using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Reservation>> GetReservationsByGuestIdAsync(int guestId);
    Task<IEnumerable<Reservation>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
}
