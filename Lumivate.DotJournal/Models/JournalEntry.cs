using System.ComponentModel.DataAnnotations;

namespace Lumivate.DotJournal.Models
{
    public class JournalEntry
    {
        // TODO-dotjournal step 1: Add the following properties:
        //   - Id (int) - primary key
        //   - Title (string) - required, the title of the journal entry
        //   - Content (string) - required, the body text of the journal entry
        //   - Mood (string) - optional, how the user is feeling (e.g. "Happy", "Stressed", "Productive")
        //   - CreatedAt (DateTime) - when the entry was created (set automatically, not a form field)
        //
        // TODO-dotjournal step 7: Add a UserId property (string) to associate entries with a user
        //   - This will be a foreign key to the Identity user table
        //   - Add [Required] to UserId
    }
}
