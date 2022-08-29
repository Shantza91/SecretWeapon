using System;
using System.Collections.Generic;

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

        public void Scored(int score)
        {
            PlayerScore += score;
        }
    }
}
