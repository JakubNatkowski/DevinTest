using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for customer operations
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId)
    {
        return await _customerRepository.GetByIdAsync(customerId);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        return await _customerRepository.AddAsync(customer);
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        await _customerRepository.DeleteAsync(customerId);
    }
}
