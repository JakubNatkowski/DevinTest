using CardDemo.Core.Entities;
using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for authentication and account management
/// Migrated from COBOL program COSGN00C
/// </summary>
public class AccountController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        IAuthenticationService authenticationService,
        ILogger<AccountController> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _authenticationService.AuthenticateAsync(model.UserId, model.Password);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid User ID or Password");
            return View(model);
        }

        // Store user information in session
        HttpContext.Session.SetString("UserId", user.UserId);
        HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");
        HttpContext.Session.SetString("UserType", user.UserType.ToString());

        _logger.LogInformation("User {UserId} logged in successfully", user.UserId);

        // Redirect based on user type
        if (user.UserType == UserType.Admin)
        {
            return RedirectToAction("Index", "Admin");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

/// <summary>
/// Login view model
/// </summary>
public class LoginViewModel
{
    [Required(ErrorMessage = "User ID is required")]
    [StringLength(8, ErrorMessage = "User ID must be 8 characters")]
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(8, ErrorMessage = "Password must be 8 characters")]
    public string Password { get; set; } = string.Empty;
}
