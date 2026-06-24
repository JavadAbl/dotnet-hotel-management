using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetByReservationIdAsync(int reservationId);
    Task<IEnumerable<Invoice>> GetByStatusAsync(string status);
}
