using System;

namespace SecretWeapon
{
    //store scores in a class with player names
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SECRET WEAPON");
            int difficulty = 0;
            while (difficulty < 4)
            {
                Console.WriteLine("ENTER DIFFICULTY");
                int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out difficulty);
            }

            Random random = new Random();
            int x = Convert.ToInt32(random.NextDouble() * difficulty + 1);
            int y = Convert.ToInt32(random.NextDouble() * difficulty + 1);
            int score = 0;
            int loop = 1;
            while( loop <= (difficulty+5))
            {
                ClearKeyPresses();
                Console.WriteLine("Guesses for X and Y");
                int x1 = 0;
                x1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"X1 selected = {x1}");
                int y1 = 0;
                y1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Y1 selected = {y1}");
                double z = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
                if( z == 0 )
                {
                    SuccessfulyDestroyed(loop);
                    score += 10;
                    Console.WriteLine($"Your score is: {score}");
                    Console.Read();
                    break;
                }
                else if(z <= 3)
                {
                    Console.WriteLine("Close");
                    score += 1;
                }
                else
                {
                    Console.WriteLine("Not even close");
                }
                loop++;
            }
            Console.WriteLine("THE ROBOTS HAVE SEEN YOU - AGGGHHHHH....");
            Console.Read();
        }

        public static void SuccessfulyDestroyed(int loop)
        {
            Console.WriteLine($"You destroyed it in {loop} goes");
        }

        static void ClearKeyPresses()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
