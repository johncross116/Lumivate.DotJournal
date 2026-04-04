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

// TODO-dotjournal step 8: Uncomment and complete the test class above

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
            Assert.NotEqual(default, saved.CreatedAt);
        }

        [Fact]
        public async Task GetAllEntriesAsync_ShouldReturnNewestFirst()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);

            // TODO-dotjournal step 8: Add two entries with different CreatedAt times
            //   and verify they come back in newest-first order
            var olderEntry = new JournalEntry { Title = "Older", Content = "First entry", UserId = "user1" };
            var newerEntry = new JournalEntry { Title = "Newer", Content = "Second entry", UserId = "user1" };

            await service.AddEntryAsync(olderEntry);
            await Task.Delay(10);
            await service.AddEntryAsync(newerEntry);

            // Act
            var entries = (await service.GetAllEntriesAsync("user1")).ToList();

            // Assert
            Assert.Equal(2, entries.Count);
            Assert.Equal("Newer", entries[0].Title);
            Assert.Equal("Older", entries[1].Title);
        }

        // TODO-dotjournal step 8: Write the remaining tests
        //   - GetEntryByIdAsync_ShouldReturnCorrectEntry
        //   - GetEntryByIdAsync_ShouldReturnNull_WhenNotFound
        //   - UpdateEntryAsync_ShouldUpdateProperties
        //   - DeleteEntryAsync_ShouldRemoveEntry

        [Fact]
        public async Task GetEntryByIdAsync_ShouldReturnCorrectEntry()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);
            var entry = new JournalEntry { Title = "Find Me", Content = "Some content", UserId = "user1" };
            await service.AddEntryAsync(entry);

            // Act
            var result = await service.GetEntryByIdAsync(entry.Id, "user1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Find Me", result.Title);
        }

        [Fact]
        public async Task GetEntryByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);

            // Act
            var result = await service.GetEntryByIdAsync(999, "user1");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateEntryAsync_ShouldUpdateProperties()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);
            var entry = new JournalEntry { Title = "Original", Content = "Original content", Mood = "Happy", UserId = "user1" };
            await service.AddEntryAsync(entry);

            // Act
            var updatedEntry = new JournalEntry { Id = entry.Id, Title = "Updated", Content = "Updated content", Mood = "Excited", UserId = "user1" };
            await service.UpdateEntryAsync(updatedEntry, "user1");

            // Assert
            var result = await context.JournalEntries.FindAsync(entry.Id);
            Assert.NotNull(result);
            Assert.Equal("Updated", result.Title);
            Assert.Equal("Updated content", result.Content);
            Assert.Equal("Excited", result.Mood);
        }

        [Fact]
        public async Task DeleteEntryAsync_ShouldRemoveEntry()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new JournalEntryService(context);
            var entry = new JournalEntry { Title = "Delete Me", Content = "To be deleted", UserId = "user1" };
            await service.AddEntryAsync(entry);

            // Act
            await service.DeleteEntryAsync(entry.Id, "user1");

            // Assert
            var result = await context.JournalEntries.FindAsync(entry.Id);
            Assert.Null(result);
        }
    }
}
