using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IGuestServiceRequestRepository : IRepository<GuestServiceRequest>
{
    Task<IEnumerable<GuestServiceRequest>> GetByReservationIdAsync(int reservationId);
    Task<IEnumerable<GuestServiceRequest>> GetByStatusAsync(string status);
}
