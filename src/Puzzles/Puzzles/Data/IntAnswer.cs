/// <summary>
/// Class defining an integer answer type
/// </summary>

namespace Puzzles.Data
{
    internal class IntAnswer : Answer
    {
        private int value;

        public IntAnswer(string name, int value)
            :base(name)
        {
            this.value = value;
        }

        public int Value
        {
            get { return this.value;  }
        }
    }
}
