using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IPaymentRepository : IRepository<Payment>
{
    Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);
}
