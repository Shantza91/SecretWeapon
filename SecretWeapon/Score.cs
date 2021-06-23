﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWeapon
{
    public class Score
    {

        public Score()
        {
        }

        string PlayerName;
        int PlayerScore = 0;

        public void UpdateScore(string name, int score)
        {
            PlayerName = name;
            PlayerScore += score;
        }

        public void DisplayScore()
        {
            Console.WriteLine($"{PlayerName}, your score is: {PlayerScore}");
        }
    }
}