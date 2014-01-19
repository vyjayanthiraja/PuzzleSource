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

namespace Puzzles.View
{
    public partial class TextAnswerPuzzlePage : PhoneApplicationPage
    {
        TextAnswerViewModel textAnswerViewModel;
        public TextAnswerPuzzlePage()
        {
            InitializeComponent();
            this.textAnswerViewModel = new TextAnswerViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            PuzzleImage.Source = new BitmapImage(new Uri(textAnswerViewModel.TextAnswer.ImageLocation, UriKind.Relative));
        }

        private void SubmitButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (textAnswerViewModel.ValidateAnswer(new StringAnswer("MCQAnswer", AnswerBox.Text)))
            {
                NavigationService.Navigate(new Uri("/View/CorrectAnswerPage.xaml", UriKind.Relative));
            }
        }

        private void TextBoxInput(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Focus();
            }
        }
    }
}