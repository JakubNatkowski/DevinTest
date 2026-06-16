using CardDemo.Core.Entities;
using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for transaction management operations
/// Migrated from COBOL programs COTRN00C, COTRN01C, COTRN02C
/// </summary>
public class TransactionManagementController : Controller
{
    private readonly ITransactionService _transactionService;
    private readonly ILogger<TransactionManagementController> _logger;

    public TransactionManagementController(
        ITransactionService transactionService,
        ILogger<TransactionManagementController> logger)
    {
        _transactionService = transactionService;
        _logger = logger;
    }

    public async Task<IActionResult> Index(long? accountId)
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var transactions = new List<Transaction>();
        
        // Get transactions by account ID if provided
        if (accountId.HasValue)
        {
            transactions = (await _transactionService.GetTransactionsByAccountIdAsync(accountId.Value)).ToList();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(transactions);
    }

    public async Task<IActionResult> Details(long id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(transaction);
    }

    public IActionResult Create()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            try
            {
                transaction.TransactionId = 0; // Let database generate ID
                transaction.TransactionDate = DateTime.Now;
                transaction.PostedIndicator = false;
                
                await _transactionService.AddTransactionAsync(transaction);
                TempData["SuccessMessage"] = "Transaction added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating transaction");
                ModelState.AddModelError("", "Unable to create transaction. Try again.");
            }
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(transaction);
    }
}
