/// <summary>
/// Tests for the Model classes
/// </summary>

namespace Puzzles.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    using Puzzles.Model;

    [TestClass]
    public class ModelTests
    {
        private const string puzzleDBConnectionString = "Data Source=isostore:/TestDB.sdf";
        private PuzzleDataContext db;

        [TestInitialize]
        public void TestDataBaseInit()
        {
            db = new PuzzleDataContext(puzzleDBConnectionString);
            if(!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
        }

        [TestMethod]
        public void TestAddRemoveTextPuzzle()
        {
            IEnumerable<Puzzle> puzzles = from Puzzle puzzle in db.puzzles
                                          select puzzle;
            Assert.AreEqual(puzzles.Count(), 0);

            TextAnswer textAnswer = new TextAnswer
            {
                Title = "TestTitle",
                ImageLocation = "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png",
                Answer = "TestAnswer"
            };

            db.puzzles.InsertOnSubmit(textAnswer);
            db.SubmitChanges();

            puzzles = from Puzzle puzzle in db.puzzles
                                          select puzzle;

            Assert.AreEqual(puzzles.Count(), 1);
            textAnswer = puzzles.First() as TextAnswer;
            Assert.AreEqual(textAnswer.Title, "TestTitle");
            Assert.AreEqual(textAnswer.ImageLocation, "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png");
            Assert.AreEqual(textAnswer.Answer, "TestAnswer");

            db.puzzles.DeleteOnSubmit(textAnswer);
            db.SubmitChanges();

            puzzles = from Puzzle puzzle in db.puzzles
                      select puzzle;
            Assert.AreEqual(puzzles.Count(), 0);
        }

        [TestMethod]
        public void TestAddRemoveMcqPuzzle()
        {
            Mcq mcq = new Mcq
            {
                Title = "TestMcq",
                ImageLocation = "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png",
                ChoicesListStr = "choice1,choice2,choice3,choice4",
                AnswerIndex = 1
            };
            db.puzzles.InsertOnSubmit(mcq);
            db.SubmitChanges();

            IEnumerable<Puzzle> puzzles = from Puzzle puzzle in db.puzzles
                      select puzzle;

            Assert.AreEqual(puzzles.Count(), 1);
            mcq = puzzles.First() as Mcq;

            Assert.AreEqual(mcq.Title, "TestMcq");
            Assert.AreEqual(mcq.ImageLocation, "/Assets/480_350_Puzzle1_Solution_Apple_InputText.png");
            Assert.AreEqual(mcq.ChoicesListStr, "choice1,choice2,choice3,choice4");
            Assert.AreEqual(mcq.AnswerIndex, 1);
            Assert.AreEqual(mcq.ChoicesList.Count, 4);
            Assert.AreEqual(mcq.ChoicesList[0], "choice1");
            Assert.AreEqual(mcq.ChoicesList[1], "choice2");
            Assert.AreEqual(mcq.ChoicesList[2], "choice3");
            Assert.AreEqual(mcq.ChoicesList[3], "choice4");

            db.puzzles.DeleteOnSubmit(mcq);
            db.SubmitChanges();

            puzzles = from Puzzle puzzle in db.puzzles
                      select puzzle;
            Assert.AreEqual(puzzles.Count(), 0);
        }
    }
}
