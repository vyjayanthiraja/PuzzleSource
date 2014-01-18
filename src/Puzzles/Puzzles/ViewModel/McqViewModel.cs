/// <summary>
/// Class implementing the view model for the MCQ class
/// </summary>

namespace Puzzles.ViewModel
{
    using Puzzles.Data;
    using Puzzles.Model;

    internal class McqViewModel : PuzzleViewModel
    {
        public McqViewModel()
        {
            using(PuzzleDataContext puzzleDb = new PuzzleDataContext(App.DbConnectionString))
            {
                this.Mcq = (Mcq)puzzleDb.GetPuzzleById(App.CurrentPuzzle);
            }
        }

        /// <summary>
        /// Gets or sets the Mcq puzzle
        /// </summary>
        public Mcq Mcq { get; private set; }

        protected override bool IsAnswerCorrect(Answer answer)
        {
            IntAnswer intAnswer = (IntAnswer)answer;
            return intAnswer.Value == Mcq.AnswerIndex;
        }
    }
}
