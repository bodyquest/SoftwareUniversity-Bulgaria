using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    class BestPlayer
    {
        static void Main(string[] args)
        {

            string namePlayer = Console.ReadLine();
            string bestPlayer = "";
            bool hatTrick = false;
            int maxGoals = 0;
            while (namePlayer != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = namePlayer;
                }
                if (maxGoals >= 3)
                {
                    hatTrick = true;
                }
                if (maxGoals >= 10)
                {
                    break;
                }
                namePlayer = Console.ReadLine();
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (hatTrick)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }








            //string namePlayer = Console.ReadLine();
            //int goals = int.Parse(Console.ReadLine());
            //int maxGoals = int.MinValue;
            //;

            //while (goals >= 10)
            //{
            //    var best = 
            //    namePlayer = best;
            //    if (goals >= 3)
            //    {
            //        maxGoals = goals;
            //        hatTrick = true;
            //    }


        }
    }
}
