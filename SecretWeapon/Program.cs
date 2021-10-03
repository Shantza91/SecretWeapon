using System;
using System.Collections.Generic;

namespace SecretWeapon
{
    //store scores in a class with player names
    // TO DO: 
    public class Program
    {
        static void Main(string[] args)
        {
            bool newRound = true;
            while (newRound)
            {
                Player firstPlayer = new Player();
                Player secondPlayer = new Player();

                Console.WriteLine("SECRET WEAPON \n");
                Console.WriteLine("Only 2 players. \n");
                Console.WriteLine("ENTER FIRST PLAYERS NAME \n");
                string name = Console.ReadLine();
                firstPlayer.UpdateScoreAndName(name, 0);

                Console.WriteLine("ENTER SECOND PLAYERS NAME\n");
                name = Console.ReadLine();
                secondPlayer.UpdateScoreAndName(name, 0);

                int difficulty = 0;
                List<Player> playerList = new List<Player>();
                playerList.Add(firstPlayer);
                playerList.Add(secondPlayer);
                
                while (difficulty < 4)
                {
                    Console.WriteLine("ENTER DIFFICULTY\n");
                    int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out difficulty);
                }

                Random random = new Random();
                int x = Convert.ToInt32(random.NextDouble() * difficulty + 1);
                int y = Convert.ToInt32(random.NextDouble() * difficulty + 1);
                int loop = 1;
                bool victory = false;

                while (loop <= (difficulty + 5))
                {
                    ClearKeyPresses();

                    foreach (Player player in playerList)
                    {

                        if (player.PlayerName == secondPlayer.PlayerName)
                        {
                            Console.WriteLine($"{player.PlayerName} is your turn! \n");
                        }
                        else
                        {
                            Console.WriteLine($"{firstPlayer.PlayerName} your turn! \n");
                        }

                        ClearKeyPresses();
                        Console.WriteLine("Guesses for X and Y");

                        int x1;
                        x1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"X1 selected = {x1}");

                        int y1;
                        y1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Y1 selected = {y1}");

                        double z = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));

                        if (z == 0)
                        {
                            victory = SuccessfulyDestroyed(loop, player.PlayerName);
                            player.PlayerScore += 10;
                            player.DisplayScore();
                            break;

                        }
                        else if (z <= 3)
                        {
                            Console.WriteLine("Close\n");
                            player.PlayerScore += 1;
                            player.DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine("Not even close\n");
                        }
                    }
                    if (victory)
                    {
                        break;
                    }
                    loop++;
                }
                if (firstPlayer.PlayerScore < (difficulty + 5) && secondPlayer.PlayerScore < (difficulty + 5))
                {
                    Console.WriteLine("THE ROBOTS HAVE SEEN YOU - AGGGHHHHH....");
                    Console.Read();
                }

                CalculateWinner(playerList);
                newRound = PlayNewRound() ? true : false;
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
            bool newRound = true;
            Console.WriteLine("WANT TO PLAY A NEW ROUND?");

            newRound = Console.ReadLine().ToString() == "y" ? newRound : false;
            return newRound;
        }
    }
}
