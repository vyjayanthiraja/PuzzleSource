/// <summary>
/// Factory class for returning a URI string to the puzzle view corresponding to a particular puzzle type
/// </summary>

namespace Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Puzzles.Model;

    internal static class PuzzlePageFactory
    {
        private static Dictionary<Type, string> typePageMap;

        public static void Init()
        {
            typePageMap = new Dictionary<Type, string>();
            typePageMap.Add(typeof(Mcq), "/View/McqPage.xaml");
            typePageMap.Add(typeof(TextAnswer), "/View/TextAnswerPage.xaml");
        }

        public static string GetPuzzlePage(Puzzle puzzle)
        {
            if(typePageMap.ContainsKey(puzzle.GetType()))
            {
                return typePageMap[puzzle.GetType()];
            }

            throw new InvalidOperationException(string.Format("Could not find a page for puzzle {0}", puzzle.GetType()));
        }
    }
}
