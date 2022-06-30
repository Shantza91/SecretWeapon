using SecretWeapon;

namespace SecretWeaponTest
{
    public class HighScoresTableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HighScoresTable_ValidPlayersAndScores_SavingHighScoresSuccessfuly()
        {
            // Arrange.
            string filePath = @"C:\Users\Shantza\source\repos\SecretWeapon\SecretWeapon\bin\Debug\Score Table.txt";
            HighScore highScoreTable = new();
            List<Player> newScores = new()
            {
                new()
                {
                    PlayerName = "Jack",
                    PlayerScore = 6
                },
                new()
                {
                    PlayerName = "George",
                    PlayerScore = 8
                },
                new()
                {
                    PlayerName = "Max",
                    PlayerScore = 10
                }
            };

            // Act.
            highScoreTable.SaveScores(newScores);

            // Assert.
            Assert.That(File.Exists(filePath), Is.True);
            Assert.That(File.ReadAllText(filePath), Does.Contain("Max"));
            Assert.That(File.ReadAllText(filePath), Does.Contain("George"));
            Assert.That(File.ReadAllText(filePath), Does.Contain("Jack"));
        }

        [Test]
        public void HighScoresTable_ValidPlayersAndScores_TopTenPlayersAreDisplayed()
        {
            // Arrange.
            string filePath = @"C:\Users\Shantza\source\repos\SecretWeapon\SecretWeapon\bin\Debug\Score Table.txt";
            HighScore highScoreTable = new();
            List<Player> newScores = new()
            {
                new()
                {
                    PlayerName = "Alice",
                    PlayerScore = 20
                },
                new()
                {
                    PlayerName = "John",
                    PlayerScore = 15
                },
                new()
                {
                    PlayerName = "Mark",
                    PlayerScore = 12
                },
                new()
                {
                    PlayerName = "Bill",
                    PlayerScore = 30
                },
                new()
                {
                    PlayerName = "James",
                    PlayerScore = 32
                }
            };

            // Act.
            highScoreTable.SaveScores(newScores);
            var topScoresDisplayed = highScoreTable.DisplayTopTenScores();

            // Assert.
            Assert.That(File.ReadAllText(filePath), Does.Contain("James"));

            // Assert that James has the highest score from all entries (first in the list).
            Assert.That(topScoresDisplayed.First().PlayerName, Is.EqualTo("James"));
        }
    }
}