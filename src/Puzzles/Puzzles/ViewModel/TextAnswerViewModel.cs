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
        public TextAnswerViewModel()
        {
            this.TextAnswer = (TextAnswer)App.CurrentPuzzle;
        }

        /// <summary>
        /// Gets or sets the TextAnswer puzzle object
        /// </summary>
        public TextAnswer TextAnswer { get; private set; }

        protected override bool IsAnswerCorrect(Answer answer)
        {
            StringAnswer stringAnswer = (StringAnswer)answer;
            return (
                string.Compare(stringAnswer.Value, TextAnswer.Answer, CultureInfo.CurrentCulture, CompareOptions.OrdinalIgnoreCase) == 0);
        }
    }
}
