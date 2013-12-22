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
                Puzzle nextPuzzle = puzzleDb.GetNextPuzzle(App.CurrentPuzzle);
                if(nextPuzzle == null)
                {
                    App.CurrentPuzzle = int.MinValue;
                }
                else
                {
                    App.CurrentPuzzle = nextPuzzle.PuzzleId;
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
