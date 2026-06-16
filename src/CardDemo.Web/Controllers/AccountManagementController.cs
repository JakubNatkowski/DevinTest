using CardDemo.Core.Entities;
using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for account management operations
/// Migrated from COBOL programs COACTUPC, COACTVWC
/// </summary>
public class AccountManagementController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ILogger<AccountManagementController> _logger;

    public AccountManagementController(
        IAccountService accountService,
        ILogger<AccountManagementController> logger)
    {
        _accountService = accountService;
        _logger = logger;
    }

    public async Task<IActionResult> Index(long? accountId)
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        // For demo purposes, show all accounts
        // In production, filter by logged-in user's customer ID
        var accounts = new List<Account>();
        
        // Get account by ID if provided
        if (accountId.HasValue)
        {
            var account = await _accountService.GetAccountByIdAsync(accountId.Value);
            if (account != null)
            {
                accounts.Add(account);
            }
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(accounts);
    }

    public async Task<IActionResult> Details(long id)
    {
        var account = await _accountService.GetAccountByIdAsync(id);
        if (account == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(account);
    }

    public async Task<IActionResult> Edit(long id)
    {
        var account = await _accountService.GetAccountByIdAsync(id);
        if (account == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(account);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, Account account)
    {
        if (id != account.AccountId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _accountService.UpdateAccountAsync(account);
                TempData["SuccessMessage"] = "Account updated successfully";
                return RedirectToAction(nameof(Details), new { id = account.AccountId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating account");
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(account);
    }
}
