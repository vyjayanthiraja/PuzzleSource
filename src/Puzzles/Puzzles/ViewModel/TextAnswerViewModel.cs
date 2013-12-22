/// <summary>
/// Class implementing the view model for the MCQ class
/// </summary>

namespace Puzzles.ViewModel
{
    using System.Globalization;

    using Puzzles.Data;
    using Puzzles.Model;

    internal class TextAnswerViewModel : PuzzleViewModel
    {
        private TextAnswer textAnswer;

        public TextAnswerViewModel()
        {
            using(PuzzleDataContext puzzleDb = new PuzzleDataContext(App.DbConnectionString))
            {
                this.textAnswer = (TextAnswer)puzzleDb.GetPuzzleById(App.CurrentPuzzle);
            }
        }

        protected override bool IsAnswerCorrect(Answer answer)
        {
            StringAnswer stringAnswer = (StringAnswer)answer;
            return (string.Compare(stringAnswer.Value, textAnswer.Answer, CultureInfo.CurrentCulture, CompareOptions.OrdinalIgnoreCase) == 0);
        }
    }
}
