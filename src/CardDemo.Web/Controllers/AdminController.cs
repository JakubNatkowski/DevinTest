using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for admin functions
/// Migrated from COBOL program COADM01C
/// </summary>
public class AdminController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<AdminController> _logger;

    public AdminController(
        IUserService userService,
        ILogger<AdminController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Check if user is authenticated and is admin
        var userId = HttpContext.Session.GetString("UserId");
        var userType = HttpContext.Session.GetString("UserType");

        if (string.IsNullOrEmpty(userId) || userType != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }
}
