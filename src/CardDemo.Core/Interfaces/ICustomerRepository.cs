using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Repository interface for Customer operations
/// </summary>
public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int customerId);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(int customerId);
}
