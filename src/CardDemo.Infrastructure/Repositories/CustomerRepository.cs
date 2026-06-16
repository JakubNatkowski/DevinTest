using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;
using CardDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for Customer operations
/// </summary>
public class CustomerRepository : ICustomerRepository
{
    private readonly CardDemoDbContext _context;

    public CustomerRepository(CardDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetByIdAsync(int customerId)
    {
        return await _context.Customers
            .Include(c => c.Accounts)
            .ThenInclude(a => a.Cards)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .Include(c => c.Accounts)
            .ToListAsync();
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteAsync(int customerId)
    {
        var customer = await GetByIdAsync(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
