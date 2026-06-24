using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Application.Contracts;

namespace Infrastructure.Repositories;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId)
    {
        return await _dbSet
            .Include(p => p.Invoice)
            .Where(p => p.InvoiceId == invoiceId)
            .ToListAsync();
    }
}
