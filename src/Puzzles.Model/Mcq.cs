/// <summary>
/// This class defines a puzzle of type MCQ
/// </summary>
/// 

namespace Puzzles.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Linq;

    public class Mcq : Puzzle
    {
        private int answerIndex;

        [Column(CanBeNull = true)]
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

        [Column(CanBeNull = true)]
        public string ChoicesListStr
        {
            get
            {
                return string.Join(",", ChoicesList);
            }
            set
            {
                this.NotifyPropertyChanging("ChoicesList");
                if(string.IsNullOrEmpty(value))
                {
                    ChoicesList = new List<string>();
                }
                else
                {
                    ChoicesList = value.Split(',').ToList();
                }
                this.NotifyPropertyChanged("ChoicesList");
            }
        }

        public List<string> ChoicesList
        {
            get;
            private set;
        }
    }
}
