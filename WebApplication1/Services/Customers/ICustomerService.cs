using WebApplication1.Models;

namespace WebApplication1.Services.Customers;

public interface ICustomerService
{
    Task<List<Customer>> GetAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}