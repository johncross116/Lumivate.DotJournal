// TODO-dotjournal step 8: Create unit tests for JournalEntryService using xUnit
//
// Use the EF Core InMemory provider to create a fake database for testing,
// just like you did in the Turtle Store project.
//
// Write tests for:
//   - AddEntryAsync: adding an entry should save it and set CreatedAt
//   - GetAllEntriesAsync: should return entries ordered by newest first
//   - GetEntryByIdAsync: should return the correct entry
//   - GetEntryByIdAsync: should return null for a non-existent id
//   - UpdateEntryAsync: should update the entry's properties
//   - DeleteEntryAsync: should remove the entry from the database

/*
using Lumivate.DotJournal.Data;
using Lumivate.DotJournal.Models;
using Lumivate.DotJournal.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Lumivate.DotJournal.Tests
{
    public class JournalEntryServiceTests
    {
        private ApplicationDbContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddEntryAsync_ShouldSaveEntry()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);
            var entry = new JournalEntry { Title = "Test Entry", Content = "Hello World", Mood = "Happy", UserId = "user1" };

            // Act
            await service.AddEntryAsync(entry);

            // Assert
            var saved = await context.JournalEntries.FirstOrDefaultAsync();
            Assert.NotNull(saved);
            Assert.Equal("Test Entry", saved.Title);
            Assert.Equal("Happy", saved.Mood);
            // TODO-dotjournal step 8: Add more assertions here
            //   - Assert that CreatedAt was set (not default DateTime)
        }

        [Fact]
        public async Task GetAllEntriesAsync_ShouldReturnNewestFirst()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);

            // TODO-dotjournal step 8: Add two entries with different CreatedAt times
            //   and verify they come back in newest-first order
        }

        // TODO-dotjournal step 8: Write the remaining tests
        //   - GetEntryByIdAsync_ShouldReturnCorrectEntry
        //   - GetEntryByIdAsync_ShouldReturnNull_WhenNotFound
        //   - UpdateEntryAsync_ShouldUpdateProperties
        //   - DeleteEntryAsync_ShouldRemoveEntry
    }
}
*/

// TODO-dotjournal step 8: Uncomment and complete the test class above
