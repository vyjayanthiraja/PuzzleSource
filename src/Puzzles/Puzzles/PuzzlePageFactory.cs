﻿/// <summary>
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
        private static string defaultLandingPage = "/View/NoPuzzlesLeftPage.xaml";

        public static void Init()
        {
            typePageMap = new Dictionary<Type, string>();
            typePageMap.Add(typeof(Mcq), "/View/McqPuzzlePage.xaml");
            typePageMap.Add(typeof(TextAnswer), "/View/TextAnswerPuzzlePage.xaml");
        }

        public static string GetPuzzlePage(Puzzle puzzle)
        {
            if (puzzle == null)
            {
                return defaultLandingPage;
            }

            if(typePageMap.ContainsKey(puzzle.GetType()))
            {
                return typePageMap[puzzle.GetType()];
            }

            throw new InvalidOperationException(string.Format("Could not find a page for puzzle {0}", puzzle.GetType()));
        }
    }
}
