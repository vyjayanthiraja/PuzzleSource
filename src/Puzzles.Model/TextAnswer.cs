/// <summary>
/// This class defines a puzzle of type TextAnswer
/// </summary>
/// 

namespace Puzzles.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;

    public class TextAnswer : Puzzle
    {
        private string answer;

        public string Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                this.NotifyPropertyChanging("Answer");
                this.answer = value;
                this.NotifyPropertyChanged("Answer");
            }
        }
    }
}
