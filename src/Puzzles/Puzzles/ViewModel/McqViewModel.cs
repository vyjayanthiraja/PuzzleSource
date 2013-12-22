/// <summary>
/// Class implementing the view model for the MCQ class
/// </summary>

namespace Puzzles.ViewModel
{
    using Puzzles.Data;
    using Puzzles.Model;

    internal class McqViewModel : PuzzleViewModel
    {
        private Mcq mcq;

        public McqViewModel()
        {
            using(PuzzleDataContext puzzleDb = new PuzzleDataContext(App.DbConnectionString))
            {
                this.mcq = (Mcq)puzzleDb.GetPuzzleById(App.CurrentPuzzle);
            }
        }

        protected override bool IsAnswerCorrect(Answer answer)
        {
            IntAnswer intAnswer = (IntAnswer)answer;
            return intAnswer.Value == mcq.AnswerIndex;
        }
    }
}
