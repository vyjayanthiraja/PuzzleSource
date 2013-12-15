/// <summary>
/// This class defines the database tables present in the Puzzles application
/// </summary>

namespace Puzzles.Model
{
    using System.Data.Linq;

    public class PuzzleDataContext : DataContext
    {
        public PuzzleDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<Puzzle> puzzles;
    }
}
