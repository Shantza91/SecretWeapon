using System;
using System.Collections.Generic;

namespace SecretWeapon
{
    // Take a look into Domain Driven Design!
    // TO DO: Change the game to be able to play with as many as specified!
    // TO DO: Lookup serialization and safe scores for every player to display a high score table.
    public class Program
    {
        static void Main(string[] args)
        {
            bool newRound = true;
            while (newRound)
            {

                Player player1 = new Player();
                Player player2 = new Player();
                Console.WriteLine("SECRET WEAPON \n");
                Console.WriteLine("Only 2 players. \n");
                Console.WriteLine("ENTER FIRST PLAYERS NAME \n");
                string name = Console.ReadLine();
                player1.UpdateScoreAndName(name, 0);

                Console.WriteLine("ENTER SECOND PLAYERS NAME\n");
                name = Console.ReadLine();
                player2.UpdateScoreAndName(name, 0);

                int difficulty = 0;
                List<Player> playerList = new List<Player>();
                playerList.Add(player1);
                playerList.Add(player2);
                
                while (difficulty < 4)
                {
                    Console.WriteLine("ENTER DIFFICULTY\n");
                    int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out difficulty);
                }

                var game = new Game(difficulty);

                int loop = 1;
                bool victory = false;

                while (loop <= (difficulty + 5))
                {
                    ClearKeyPresses();

                    foreach (Player player in playerList)
                    {
                        Console.WriteLine($"{player.PlayerName} is your turn! \n");

                        ClearKeyPresses();
                        Console.WriteLine("Guesses for X and Y");

                        int x1;
                        x1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"X1 selected = {x1}");

                        int y1;
                        y1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Y1 selected = {y1}");

                        var z = game.Fire(x1, y1);

                        if (z == 0)
                        {
                            victory = SuccessfulyDestroyed(loop, player.PlayerName);
                            player.PlayerScore += 10;
                            break;

                        }
                        else if (z <= 3)
                        {
                            Console.WriteLine("Close\n");
                            player.PlayerScore += 1;
                        }
                        else
                        {
                            Console.WriteLine("Not even close\n");
                        }

                        player.DisplayScore();
                    }
                    if (victory)
                    {
                        break;
                    }
                    loop++;
                }
                if (player1.PlayerScore < (difficulty + 5) && player2.PlayerScore < (difficulty + 5))
                {
                    Console.WriteLine("THE ROBOTS HAVE SEEN YOU - AGGGHHHHH....");
                    Console.Read();
                }

                CalculateWinner(playerList);
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
            if(playerList[0].PlayerScore > playerList[1].PlayerScore)
            {
                Console.WriteLine($"{playerList[0].PlayerName} is the WINNER!");
            }
            else if(playerList[0].PlayerScore < playerList[1].PlayerScore)
            {
                Console.WriteLine($"{playerList[1].PlayerName} is the WINNER!");
            }
            else
            {
                Console.WriteLine("IT'S DRAW");
            }
        }

        public static bool PlayNewRound()
        {
            Console.WriteLine("WANT TO PLAY A NEW ROUND?");

            return Console.ReadLine().ToString() == "y";
        }
    }
}
