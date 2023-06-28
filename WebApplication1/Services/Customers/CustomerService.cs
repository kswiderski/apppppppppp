using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Persistence;

namespace WebApplication1.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly DatabaseContext _context;

    public CustomerService(DatabaseContext context) { _context = context; }

    public async Task<List<Customer>> GetAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task AddAsync(Customer customer)
    {
        var existingCustomer = await GetByIdAsync(customer.Id);

        if (existingCustomer is null)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Customer customer)
    {
        var existingCustomer = await GetByIdAsync(customer.Id);

        if (existingCustomer is not null)
        {
            existingCustomer.Name = customer.Name;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);

        if (customer is not null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}