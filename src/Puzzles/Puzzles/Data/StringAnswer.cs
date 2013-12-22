/// <summary>
/// Class defining an string answer type
/// </summary>

namespace Puzzles.Data
{
    internal class StringAnswer : Answer
    {
        private string value;

        public StringAnswer(string name, string value)
            :base(name)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}
