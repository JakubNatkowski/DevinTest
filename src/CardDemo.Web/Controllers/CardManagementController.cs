using CardDemo.Core.Entities;
using CardDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardDemo.Web.Controllers;

/// <summary>
/// Controller for credit card management operations
/// Migrated from COBOL programs COCRDUPC, COCRDLIC, COCRDSLC
/// </summary>
public class CardManagementController : Controller
{
    private readonly ICardService _cardService;
    private readonly IAccountService _accountService;
    private readonly ILogger<CardManagementController> _logger;

    public CardManagementController(
        ICardService cardService,
        IAccountService accountService,
        ILogger<CardManagementController> logger)
    {
        _cardService = cardService;
        _accountService = accountService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var cards = new List<Card>();
        
        // Get cards by account ID if provided
        if (TempData["AccountId"] != null)
        {
            var accountId = Convert.ToInt64(TempData["AccountId"]);
            cards = (await _cardService.GetCardsByAccountIdAsync(accountId)).ToList();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(cards);
    }

    public async Task<IActionResult> Details(string id)
    {
        var card = await _cardService.GetCardByCardNumberAsync(id);
        if (card == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(card);
    }

    public IActionResult Create()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Card card)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _cardService.AddCardAsync(card);
                TempData["SuccessMessage"] = "Card created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating card");
                ModelState.AddModelError("", "Unable to create card. Try again.");
            }
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(card);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var card = await _cardService.GetCardByCardNumberAsync(id);
        if (card == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(card);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, Card card)
    {
        if (id != card.CardNumber)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _cardService.UpdateCardAsync(card);
                TempData["SuccessMessage"] = "Card updated successfully";
                return RedirectToAction(nameof(Details), new { id = card.CardNumber });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating card");
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(card);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var card = await _cardService.GetCardByCardNumberAsync(id);
        if (card == null)
        {
            return NotFound();
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View(card);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _cardService.DeleteCardAsync(id);
        TempData["SuccessMessage"] = "Card deleted successfully";
        return RedirectToAction(nameof(Index));
    }
}
