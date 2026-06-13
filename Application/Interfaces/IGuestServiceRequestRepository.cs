using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IGuestServiceRequestRepository : IRepository<GuestServiceRequest>
{
    Task<IEnumerable<GuestServiceRequest>> GetByReservationIdAsync(int reservationId);
    Task<IEnumerable<GuestServiceRequest>> GetByStatusAsync(string status);
}
