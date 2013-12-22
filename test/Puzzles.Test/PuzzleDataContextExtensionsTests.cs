/// <summary>
/// Tests for the PuzzleDataContextExtensions class
/// </summary>

namespace Puzzles.Test
{
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    using Puzzles.Model;

    [TestClass]
    public class PuzzleDataContextExtensionsTests
    {
        private const string puzzleDBConnectionString = "Data Source=isostore:/TestDB.sdf";
        private PuzzleDataContext db;

        [TestInitialize]
        public void TestDataBaseInit()
        {
            db = new PuzzleDataContext(puzzleDBConnectionString);
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }

            TextAnswer textAnswer = new TextAnswer
            {
                Title = "TestTitle",
                ImageLocation = "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png",
                Answer = "TestAnswer"
            };

            db.puzzles.InsertOnSubmit(textAnswer);

            Mcq mcq = new Mcq
            {
                Title = "TestMcq",
                ImageLocation = "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png",
                ChoicesListStr = "choice1,choice2,choice3,choice4",
                AnswerIndex = 1
            };

            db.puzzles.InsertOnSubmit(mcq);

            db.SubmitChanges();
        }

        [TestMethod]
        public void TestGetFirstPuzzle()
        {
            Puzzle puzzle = db.GetFirstPuzzle();
            Assert.AreEqual(puzzle.GetType(), typeof(TextAnswer));
            TextAnswer textAnswer = puzzle as TextAnswer;

            Assert.AreEqual(textAnswer.Answer, "TestAnswer");
            Assert.AreEqual(textAnswer.Title, "TestTitle");
            Assert.AreEqual(textAnswer.ImageLocation, "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png");
        }

        [TestMethod]
        public void TestGetPuzzleById()
        {
            Puzzle puzzle1 = db.GetFirstPuzzle();
            int puzzleId = puzzle1.PuzzleId;

            Puzzle puzzle2 = db.GetPuzzleById(puzzleId);

            Assert.IsNotNull(puzzle2);
            Assert.AreEqual(puzzle1.GetType(), puzzle2.GetType());
            Assert.AreEqual(puzzle1.Title, puzzle2.Title);
            Assert.AreEqual(puzzle1.ImageLocation, puzzle2.ImageLocation);
        }

        [TestMethod]
        public void TestGetNextPuzzle()
        {
            Puzzle firstPuzzle = db.GetFirstPuzzle();

            Puzzle secondPuzzle = db.GetNextPuzzle(firstPuzzle.PuzzleId);
            Assert.IsNotNull(secondPuzzle);
            Assert.AreEqual(secondPuzzle.GetType(), typeof(Mcq));
            Assert.AreEqual(secondPuzzle.Title, "TestMcq");
            Assert.AreEqual(secondPuzzle.ImageLocation, "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png");
        }
    }
}
