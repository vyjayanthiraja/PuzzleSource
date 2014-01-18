using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using Puzzles.Model;
using Puzzles.ViewModel;
using System.Windows.Input;

namespace Puzzles.View
{
    public partial class MCQPuzzlePage : PhoneApplicationPage
    {
        McqViewModel mcqViewModel;

        public MCQPuzzlePage()
        {
            InitializeComponent();
            this.mcqViewModel = new McqViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PuzzleImage.Source = new BitmapImage(new Uri(mcqViewModel.Mcq.ImageLocation, UriKind.Relative));
            Answer0.Source = new BitmapImage(new Uri(mcqViewModel.Mcq.ChoicesList[0], UriKind.Relative));
            Answer1.Source = new BitmapImage(new Uri(mcqViewModel.Mcq.ChoicesList[1], UriKind.Relative));
            if (mcqViewModel.Mcq.ChoicesList.Count > 2)
            {
                Answer2.Source = new BitmapImage(new Uri(mcqViewModel.Mcq.ChoicesList[2], UriKind.Relative));
                Answer3.Source = new BitmapImage(new Uri(mcqViewModel.Mcq.ChoicesList[3], UriKind.Relative));
            }
        }

        private void SubmitButton_Tap(object sender, GestureEventArgs e)
        {

        }

        private void HintButton_Tap(object sender, GestureEventArgs e)
        {
            
        }

        private void Answer_Tap(object sender, GestureEventArgs e)
        {

        }
    }
}