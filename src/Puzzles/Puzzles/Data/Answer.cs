/// <summary>
/// Abstract class for various puzzle answer types
/// </summary>

namespace Puzzles.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal abstract class Answer
    {
        private string name;

        public Answer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name;  }
        }
    }
}
