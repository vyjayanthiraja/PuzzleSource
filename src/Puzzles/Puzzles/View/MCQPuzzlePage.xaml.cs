namespace Puzzles.View
{
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

    using Puzzles.Model;
    using Puzzles.ViewModel;
    using System.Windows.Input;
    using Puzzles.Data;

    public partial class MCQPuzzlePage : PhoneApplicationPage
    {
        McqViewModel mcqViewModel;
        int currentChoice;

        public MCQPuzzlePage()
        {
            InitializeComponent();
            this.mcqViewModel = new McqViewModel();
            this.currentChoice = -1;
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
            if (mcqViewModel.ValidateAnswer(new IntAnswer("MCQAnswer", currentChoice)))
            {
                NavigationService.Navigate(new Uri("/View/CorrectAnswerPage.xaml", UriKind.Relative));
            }

        }

        private void Answer_Tap(object sender, GestureEventArgs e)
        {
            Image clickedImage = sender as Image;
            if (clickedImage == null)
            {
                return;
            }

            switch (clickedImage.Name)
            {
                case "Answer0":
                    currentChoice = 0;
                    break;
                case "Answer1":
                    currentChoice = 1;
                    break;
                case "Answer2":
                    currentChoice = 2;
                    break;
                case "Answer3":
                    currentChoice = 3;
                    break;
                default:
                    currentChoice = -1;
                    break;
            }

            if (currentChoice >= mcqViewModel.Mcq.ChoicesList.Count)
            {
                currentChoice = -1;
            }
        }
    }
}