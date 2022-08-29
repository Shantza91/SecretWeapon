using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SecretWeapon
{
    // Take a look into Domain Driven Design!
    // TO DO: Change the game to be able to play with as many players as specified! - done
    // TO DO: Lookup serialization and save scores for every player to display a high score table. - done
    public class Program
    {
        static void Main(string[] args)
        {
            bool newRound = true;

            Console.WriteLine("SECRET WEAPON \n");
            HighScore highScore = new HighScore();

            highScore.LoadScores();

            while (newRound)
            {
                
                // Setup difficulty.
                int difficulty = 0;
                while (difficulty < 4)
                {
                    Console.WriteLine("ENTER DIFFICULTY\n");
                    int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out difficulty);
                }

                var game = new Game(difficulty);

                // Setup and manage Player input.
                var playerList = game.AddPlayers();

                int loop = 1;
                bool victory = false;
                while (loop <= (difficulty + 5))
                {
                    // Skip statement, remove after debug!
                    Console.WriteLine("DO YOU WANT TO SKIP?");
                    if (Console.ReadLine() == "y")
                    {
                        break;
                    }

                    foreach (var playerStatus in playerList)
                    {
                        ClearKeyPresses();
                        Console.WriteLine($"{playerStatus.PlayerName} is your turn! \n");

                        ClearKeyPresses();
                        Console.WriteLine("Guesses for X and Y:\n");

                        int x1;
                        x1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"X1 selected = {x1}.\n");

                        int y1;
                        y1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Y1 selected = {y1}.\n");

                        var z = game.Fire(x1, y1);

                        if (z == 0)
                        {
                            victory = SuccessfulyDestroyed(loop, playerStatus.PlayerName);
                            playerStatus.Scored(10);

                            Console.Read();
                            break;
                        }
                        else if (z <= 3)
                        {
                            Console.WriteLine("Close.\n");
                            playerStatus.Scored(1);
                        }
                        else
                        {
                            Console.WriteLine("Not even close.\n");
                        }

                        playerStatus.DisplayScore();
                    }
                    loop++;
                }
                if(!victory)
                {
                    Console.WriteLine("THE ROBOTS HAVE SEEN YOU - AGGGHHHHH....");
                    Console.Read();
                }

                CalculateWinner(playerList);

                // Saving scores to file.                
                highScore.SaveScores(playerList);

                // Display top 10 scores if there are at least 10 players that have played.
                highScore.DisplayTopTenScores();

                newRound = PlayNewRound();
            }
        }

        public static bool SuccessfulyDestroyed(int loop, string playerName)
        {
            Console.WriteLine($"{playerName} destroyed it in {loop} go(s) !\n");
            return true;
        }

        static void ClearKeyPresses()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static void CalculateWinner(List<Player> playerList)
        {
            List<int> scoreList = new List<int>();
            foreach(Player player in playerList)
            {
                scoreList.Add(player.PlayerScore);
            }

            foreach (Player player in playerList)
            {
                int playerHighestScore = scoreList.Max();
                if (player.PlayerScore == playerHighestScore)
                {
                    Console.WriteLine($"{player.PlayerName} is the WINNER!");
                }
            }
        }

        public static bool PlayNewRound()
        {
            Console.WriteLine("WANT TO PLAY A NEW ROUND?");

            return Console.ReadLine().ToString() == "y";
        }
    }
}
