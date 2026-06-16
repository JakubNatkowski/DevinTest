using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for user management operations
/// Migrated from COBOL programs COUSR00C, COUSR01C, COUSR02C, COUSR03C
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> AddUserAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(string userId)
    {
        await _userRepository.DeleteAsync(userId);
    }
}
