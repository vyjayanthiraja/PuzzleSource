using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Puzzles.View
{
    public enum PuzzleType { MCQ,InputText};
    public class Puzzle
    {
        public bool checkSolution(String sol)
        {
            return sol.ToLowerInvariant() == solution.ToLowerInvariant();  
        }
        public PuzzleType type = PuzzleType.InputText;
        public Uri image = new Uri("/Assets/480_350_Puzzle1_Solution_Apple_InputText.png", UriKind.Relative);
        public String solution = "apple";
        public IList<Uri> solutionImageList = null;
    }
    
    public partial class PuzzlePage : PhoneApplicationPage
    {
        public IList<Puzzle> puzzleList;
        public PuzzlePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Puzzle puzzle = new Puzzle();
            //MCQ stuff:
            //            <Grid.RowDefinitions>
            //    <RowDefinition Height="*"/>
            //    <RowDefinition Height="*"/>
            //</Grid.RowDefinitions>
            //<Grid.ColumnDefinitions>
            //    <ColumnDefinition Width="*"/>
            //    <ColumnDefinition Width="*"/>
            //</Grid.ColumnDefinitions>

            if (puzzle.type == PuzzleType.InputText)
            {
                //InputText stuff:
                //<TextBox HorizontalAlignment="Left" Height="97" Margin="40,50,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="403"/>
                TextBox answerBox = new TextBox();
                
            }
            PuzzleImage.Source = new System.Windows.Media.Imaging.BitmapImage(puzzle.image);
        }

        private void SubmitButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PuzzleImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("/Assets/480_350_Puzzle2_Solution_Cricket_InputText.png", UriKind.Relative));
        }

        private void HintButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PuzzleImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("/Assets/480_350_Puzzle1_Solution_Apple_InputText.png", UriKind.Relative));
        }

        private void answerField_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //NavigationService.GoBack();
        }
    }
}