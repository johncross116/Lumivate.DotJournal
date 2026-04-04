using Lumivate.DotJournal.Models;
using Lumivate.DotJournal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lumivate.DotJournal.Controllers
{
    // TODO-dotjournal step 7: Add the [Authorize] attribute to the entire controller
    //   This ensures only logged-in users can access journal entries.
    //   [Authorize]
    public class JournalEntriesController : Controller
    {
        // TODO-dotjournal step 4: Set up the controller
        //
        // 1. Accept IJournalEntryService via constructor injection
        // 2. Add the following actions:
        //
        //   Index [HttpGet]: Get all journal entries and pass them to the view
        //     return View(await _journalEntryService.GetAllEntriesAsync());
        //
        //   Details(int id) [HttpGet]: Get a single entry by id
        //     If not found, return NotFound()
        //     Otherwise return View(entry)
        //
        //   Create [HttpGet]: Return the Create view
        //     return View();
        //
        //   Create(JournalEntry entry) [HttpPost]: Save a new entry
        //     Call _journalEntryService.AddEntryAsync(entry)
        //     Redirect to Index
        //
        //   Edit(int id) [HttpGet]: Get entry by id for editing
        //     If not found, return NotFound()
        //     Otherwise return View(entry)
        //
        //   Edit(int id, JournalEntry entry) [HttpPost]: Update an existing entry
        //     Call _journalEntryService.UpdateEntryAsync(entry)
        //     Redirect to Index
        //
        //   Delete(int id) [HttpGet]: Get entry by id for delete confirmation
        //     If not found, return NotFound()
        //     Otherwise return View(entry)
        //
        //   DeleteConfirmed(int id) [HttpPost, ActionName("Delete")]: Actually delete the entry
        //     Call _journalEntryService.DeleteEntryAsync(id)
        //     Redirect to Index
        //
        // TODO-dotjournal step 7: Get the current user's ID in each action method:
        //   var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //   Pass userId to the service methods so entries are scoped to the logged-in user.
        //   When creating a new entry, set entry.UserId = userId before saving.
    }
}
