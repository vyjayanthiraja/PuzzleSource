/// <summary>
/// Tests for the Model classes
/// </summary>

namespace Puzzles.Test
{
    using System;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    using Puzzles.Model;

    [TestClass]
    public class ModelTests
    {
        private const string puzzleDBConnectionString = "Data Source=isostore:/TestAdminDB.sdf";

        [TestMethod]
        public void TestDataBaseInit()
        {
            using (PuzzleDataContext db = new PuzzleDataContext(puzzleDBConnectionString))
            {
                if (!db.DatabaseExists())
                {
                    db.CreateDatabase();
                }
            }
        }
    }
}
