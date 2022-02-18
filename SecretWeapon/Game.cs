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
    }
}
