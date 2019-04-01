using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Phase
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int numGames = int.Parse(Console.ReadLine());

            int scored = 0;
            int lost = 0;
            int goalDiff = 0;
            int sumGoalDiff = 0;
            int scores = 0;

            for (int game = 1; game <= numGames; game++)
            {
                scored = int.Parse(Console.ReadLine());
                lost = int.Parse(Console.ReadLine());
                goalDiff = scored - lost;
                sumGoalDiff += goalDiff;
                if (goalDiff > 0)
                {
                    scores += 3;
                }
                else if(goalDiff == 0)
                {
                    scores += 1;  
                }
                else
                {
                    scores += 0;
                }
            }

            if (sumGoalDiff >= 0)
            {
                Console.WriteLine($"{team} has finished the group phase with {scores} points.");
                Console.WriteLine($"Goal difference: {sumGoalDiff}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {sumGoalDiff}.");
            }
        }
    }
}
