using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Reservation>> GetReservationsByGuestIdAsync(int guestId);
    Task<IEnumerable<Reservation>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
}
