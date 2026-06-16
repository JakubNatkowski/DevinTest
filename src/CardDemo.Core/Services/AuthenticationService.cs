using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for authentication operations
/// Migrated from COBOL program COSGN00C
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> AuthenticateAsync(string userId, string password)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
        {
            return null;
        }

        return await _userRepository.AuthenticateAsync(userId, password);
    }

    public async Task<bool> IsAdminUserAsync(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return user?.UserType == UserType.Admin;
    }
}
