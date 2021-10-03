﻿using System;
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

        public void UpdateScoreAndName(string name, int score)
        {
            PlayerName = name;
            PlayerScore = score;
        }

        public void DisplayScore()
        {
            Console.WriteLine($"{PlayerName}, your score is: {PlayerScore}");
        }
    }
}