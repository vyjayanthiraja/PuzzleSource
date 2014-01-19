using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace Puzzles.View
{
    public partial class CorrectAnswerPage : PhoneApplicationPage
    {
        public CorrectAnswerPage()
        {
            InitializeComponent();
        }

        private void NextPuzzleButton_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri(PuzzlePageFactory.GetPuzzlePage(App.CurrentPuzzle), UriKind.Relative));
        }
    }
}