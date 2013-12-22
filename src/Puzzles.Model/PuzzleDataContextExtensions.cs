/// <summary>
/// Extension methods to retrieve puzzle objects from the database
/// </summary>

namespace Puzzles.Model
{
    using System.Linq;

    public static class PuzzleDataContextExtensions
    {
        /// <summary>
        /// Gets the first puzzle in the database
        /// </summary>
        /// <param name="puzzleDb">The puzzle data context object</param>
        /// <returns>The first puzzle object in the database or null, if the database is empty</returns>
        public static Puzzle GetFirstPuzzle(this PuzzleDataContext puzzleDb)
        {
            Puzzle puzzle = (from Puzzle p in puzzleDb.puzzles
                             orderby p.PuzzleId ascending
                             select p).FirstOrDefault();

            return puzzle;
        }

        /// <summary>
        /// Gets a puzzle from the database by id
        /// </summary>
        /// <param name="puzzleDb">The Puzzle data context object</param>
        /// <param name="puzzleId">The puzzle id</param>
        /// <returns>The puzzle corresponding to the id or null, if no such puzzle exists</returns>
        public static Puzzle GetPuzzleById(this PuzzleDataContext puzzleDb, int puzzleId)
        {
            Puzzle puzzle = (from Puzzle p in puzzleDb.puzzles
                             where p.PuzzleId == puzzleId
                             select p).FirstOrDefault();

            return puzzle;
        }

        /// <summary>
        /// Gets the puzzle from the database that immediately follows the input puzzle (specified by id)
        /// </summary>
        /// <param name="puzzleDb">The puzzle data context object</param>
        /// <param name="puzzleId">The puzzle id</param>
        /// <returns>The next puzzle or null, if no such puzzle exists</returns>
        public static Puzzle GetNextPuzzle(this PuzzleDataContext puzzleDb, int puzzleId)
        {
            Puzzle puzzle = (from Puzzle p in puzzleDb.puzzles
                             where p.PuzzleId > puzzleId
                             orderby p.PuzzleId
                             select p).FirstOrDefault();

            return puzzle;
        }
    }
}
