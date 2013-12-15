/// <summary>
/// This class defines a puzzle of type MCQ
/// </summary>
/// 

namespace Puzzles.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;

    public class Mcq : Puzzle
    {
        private int answerIndex;

        public int AnswerIndex
        {
            get
            {
                return this.answerIndex;
            }
            set
            {
                this.NotifyPropertyChanging("AnswerIndex");
                this.answerIndex = value;
                this.NotifyPropertyChanged("AnswerIndex");
            }
        }
    }
}
