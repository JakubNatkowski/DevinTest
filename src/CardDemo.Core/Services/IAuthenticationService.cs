using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for authentication operations
/// Migrated from COBOL program COSGN00C
/// </summary>
public interface IAuthenticationService
{
    Task<User?> AuthenticateAsync(string userId, string password);
    Task<bool> IsAdminUserAsync(string userId);
}
