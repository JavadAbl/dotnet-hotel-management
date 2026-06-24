using Application.Contracts.Repositories;
using Domain.Models;
using Domain.Enums;

namespace Application.Contracts;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetByReservationIdAsync(int reservationId);
    Task<IEnumerable<Invoice>> GetByStatusAsync(InvoiceStatus status);
}
