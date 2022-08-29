using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWeapon
{
    internal class Game
    {
        public int x;
        public int y;

        public Game(int difficulty)
        {
            Random random = new Random();
            x = Convert.ToInt32(random.NextDouble() * difficulty + 1);
            y = Convert.ToInt32(random.NextDouble() * difficulty + 1);
        }

        public double Fire(int x, int y)
        {
            double z = Math.Sqrt((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y));

            return z;
        }

        public List<Player> AddPlayers()
        {
            List<Player> playerList = new List<Player>();

            Console.WriteLine("Enter number of players. \n");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Player player = new Player();
                Console.WriteLine($"ENTER {i} PLAYERS NAME \n");
                string playerName = Console.ReadLine();
                player.UpdateNameAndScore(playerName, 0);
                playerList.Add(player);
            }

            return playerList;
        }
    }
}
