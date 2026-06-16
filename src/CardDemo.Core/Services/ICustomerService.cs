using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for customer operations
/// </summary>
public interface ICustomerService
{
    Task<Customer?> GetCustomerByIdAsync(int customerId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> AddCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int customerId);
}
