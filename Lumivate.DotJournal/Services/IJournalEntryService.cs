using Lumivate.DotJournal.Models;

namespace Lumivate.DotJournal.Services
{
    public interface IJournalEntryService
    {
        // TODO-dotjournal step 3: Define these methods:
        //   - Task<IEnumerable<JournalEntry>> GetAllEntriesAsync()
        //   - Task<JournalEntry?> GetEntryByIdAsync(int id)
        //   - Task AddEntryAsync(JournalEntry entry)
        //   - Task UpdateEntryAsync(JournalEntry entry)
        //   - Task DeleteEntryAsync(int id)
        //
        // TODO-dotjournal step 7: Update the interface methods to accept a userId parameter
        //   - GetAllEntriesAsync(string userId) - only return entries for this user
        //   - GetEntryByIdAsync(int id, string userId) - only return if it belongs to this user
        //   - AddEntryAsync(JournalEntry entry) - entry.UserId should already be set by the controller
        //   - UpdateEntryAsync(JournalEntry entry, string userId) - verify ownership before updating
        //   - DeleteEntryAsync(int id, string userId) - verify ownership before deleting

        Task<IEnumerable<JournalEntry>> GetAllEntriesAsync(string userId);
        Task<JournalEntry?> GetEntryByIdAsync(int id, string userId);
        Task AddEntryAsync(JournalEntry entry);
        Task UpdateEntryAsync(JournalEntry entry, string userId);
        Task DeleteEntryAsync(int id, string userId);
    }
}
