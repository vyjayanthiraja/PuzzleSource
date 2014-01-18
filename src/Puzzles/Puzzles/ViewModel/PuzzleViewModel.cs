/// <summary>
/// Base puzzle view model class
/// </summary>

namespace Puzzles.ViewModel
{
    using Puzzles.Data;
    using Puzzles.Model;

    internal abstract class PuzzleViewModel
    {
        public PuzzleViewModel()
        {
        }

        protected abstract bool IsAnswerCorrect(Answer answer);

        protected void UpdateCurrentPuzzle()
        {
            using(PuzzleDataContext puzzleDb = new PuzzleDataContext(App.DbConnectionString))
            {
                Puzzle nextPuzzle = puzzleDb.GetNextPuzzle(App.CurrentPuzzle.PuzzleId);
                if(nextPuzzle == null)
                {
                    App.CurrentPuzzle = null;
                }
                else
                {
                    App.CurrentPuzzle = nextPuzzle;
                }
            }
        }
        
        public bool ValidateAnswer(Answer answer)
        {
            if(IsAnswerCorrect(answer))
            {
                UpdateCurrentPuzzle();
                return true;
            }

            return false;
        }
    }
}
