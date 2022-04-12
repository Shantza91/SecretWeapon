using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWeapon
{
    public class Player
    {

        public Player()
        {
        }

        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }

        public void UpdateNameAndScore(string name, int score)
        {
            PlayerName = name;
            PlayerScore = score;
        }

        public void DisplayScore()
        {
            Console.WriteLine($"{PlayerName}, your score is: {PlayerScore}.\n");
        }

        public List<Player> AddPlayers()
        {
            List<Player> playerList = new List<Player>();
            
            Console.WriteLine("Enter number of players. \n");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i <= numberOfPlayers; i++)
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
