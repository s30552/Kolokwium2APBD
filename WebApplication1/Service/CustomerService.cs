using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Service;

public class CustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PurchaseDto?> GetCustomerPurchasesAsync(int customerId)
    {
        var customer = await _context.Customers
            .Include(c => c.Purchases)
            .ThenInclude(p => p.WashingMachine)
            .Include(c => c.Purchases)
            .ThenInclude(p => p.Program)
            .FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer == null)
            return null;

        return new PurchaseDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.Purchases.Select(p => new
            {
                date = p.Date,
                rating = p.Rating,
                price = p.Price,
                washingMachine = new
                {
                    serial = p.WashingMachine.SerialNumber,
                    maxWeight = p.WashingMachine.MaxWeight
                },
                program = new
                {
                    name = p.Program.Name,
                    duration = p.Program.Duration
                }
            })
        };
    }
}
