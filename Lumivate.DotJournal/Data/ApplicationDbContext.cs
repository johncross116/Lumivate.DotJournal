using Lumivate.DotJournal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lumivate.DotJournal.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
	{
		// TODO-dotjournal step 2: Add a DbSet for JournalEntry
		//   public DbSet<JournalEntry> JournalEntries { get; set; }
		//
		// Then run the migration commands in the Package Manager Console
		// (Tools > NuGet Package Manager > Package Manager Console):
		//   Add-Migration AddJournalEntries
		//   Update-Database
		//
		// TODO-dotjournal step 7: After adding UserId to JournalEntry, create another migration:
		// (Tools > NuGet Package Manager > Package Manager Console):
		//   Add-Migration AddUserIdToJournalEntry
		//   Update-Database

		public DbSet<JournalEntry> JournalEntries { get; set; }
	}
}
