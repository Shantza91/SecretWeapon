using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWeapon
{
    public class HighScore
    {
        // Tidy up SaveScores();
        // Test the HighScore class (unit test) without running the game.
        // Display of top 10 scores.
        List<Player> _highScores;
        readonly string _filePath = @"C:\Users\Shantza\source\repos\SecretWeapon\SecretWeapon\bin\Debug\Score Table.txt";

        public void SaveScores(List<Player> newScores)
        {
            UpdateScores(newScores);

            if (File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(_highScores));
            }
        }

        public void LoadScores()
        {
            if (File.Exists(_filePath))
            {
                _highScores = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(_filePath));
            }
        }

        public List<Player> DisplayTopTenScores()
        {
            LoadScores();

            List<Player> orderedListOfPlayers = _highScores.OrderByDescending(x => x.PlayerScore).ToList();

            if (orderedListOfPlayers.Count >= 10)
            {
                for (var i = 0; i == 10; i++)
                {
                    Console.WriteLine($"Top 10 players are: \n {orderedListOfPlayers[i].PlayerName} with score = {orderedListOfPlayers[i].PlayerScore} \n");
                }
            }

            return orderedListOfPlayers;
        }

        public void UpdateScores(List<Player> newScores)
        {
            LoadScores();

            foreach (Player player in newScores)
            {
                if (_highScores.Where(x => x.PlayerName == player.PlayerName).Any())
                {
                    var playerHighScore = _highScores.Where(x => x.PlayerName == player.PlayerName).First();
                    if (playerHighScore.PlayerScore < player.PlayerScore)
                    {
                        playerHighScore.PlayerScore = player.PlayerScore;
                    }
                }
                else
                {
                    _highScores.Add(player);
                }
            }
        }
    }
}
