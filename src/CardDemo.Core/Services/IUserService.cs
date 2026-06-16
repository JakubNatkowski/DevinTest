using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for user management operations
/// Migrated from COBOL programs COUSR00C, COUSR01C, COUSR02C, COUSR03C
/// </summary>
public interface IUserService
{
    Task<User?> GetUserByIdAsync(string userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(string userId);
}
