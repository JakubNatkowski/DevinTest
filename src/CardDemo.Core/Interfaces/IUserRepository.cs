using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Repository interface for User operations
/// </summary>
public interface IUserRepository
{
    Task<User?> GetByIdAsync(string userId);
    Task<User?> AuthenticateAsync(string userId, string password);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(string userId);
}
