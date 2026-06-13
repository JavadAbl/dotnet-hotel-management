using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetByReservationIdAsync(int reservationId);
    Task<IEnumerable<Invoice>> GetByStatusAsync(string status);
}
