using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for main menu and home page
/// Migrated from COBOL program COMEN01C
/// </summary>
public class HomeController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ICardService _cardService;
    private readonly ITransactionService _transactionService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        IAccountService accountService,
        ICardService cardService,
        ITransactionService transactionService,
        ILogger<HomeController> logger)
    {
        _accountService = accountService;
        _cardService = cardService;
        _transactionService = transactionService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Check if user is authenticated
        var userId = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }
}
