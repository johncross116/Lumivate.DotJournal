using Lumivate.DotJournal.Data;
using Lumivate.DotJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace Lumivate.DotJournal.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        // TODO-dotjournal step 3: Implement the JournalEntryService
        //
        // This service should:
        //   1. Accept ApplicationDbContext via constructor injection
        //   2. Implement all methods from the interface using EF Core:
        //      - GetAllEntriesAsync(): return all entries ordered by CreatedAt descending (newest first)
        //      - GetEntryByIdAsync(int id): find by id, return null if not found
        //      - AddEntryAsync(JournalEntry entry): set CreatedAt = DateTime.Now, then add and save
        //      - UpdateEntryAsync(JournalEntry entry): update and save
        //      - DeleteEntryAsync(int id): find by id, remove, and save
        //
        // TODO-dotjournal step 3: After implementing this class, register it in Program.cs:
        //   builder.Services.AddScoped<IJournalEntryService, JournalEntryService>();
        //
        // TODO-dotjournal step 7: Update all methods to filter by userId
        //   - GetAllEntriesAsync(string userId): filter with .Where(e => e.UserId == userId)
        //   - GetEntryByIdAsync(int id, string userId): filter by both id AND userId
        //   - UpdateEntryAsync(JournalEntry entry, string userId): verify UserId matches before saving
        //   - DeleteEntryAsync(int id, string userId): verify UserId matches before deleting

        private readonly ApplicationDbContext _context;

        public JournalEntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JournalEntry>> GetAllEntriesAsync(string userId)
        {
            return await _context.JournalEntries
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<JournalEntry?> GetEntryByIdAsync(int id, string userId)
        {
            return await _context.JournalEntries
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
        }

        public async Task AddEntryAsync(JournalEntry entry)
        {
            entry.CreatedAt = DateTime.Now;
            _context.JournalEntries.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntryAsync(JournalEntry entry, string userId)
        {
            var existing = await _context.JournalEntries
                .FirstOrDefaultAsync(e => e.Id == entry.Id && e.UserId == userId);

            if (existing != null)
            {
                existing.Title = entry.Title;
                existing.Content = entry.Content;
                existing.Mood = entry.Mood;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEntryAsync(int id, string userId)
        {
            var entry = await _context.JournalEntries
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

            if (entry != null)
            {
                _context.JournalEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
