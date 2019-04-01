using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStage
{
    class GroupStage
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int numPlays = int.Parse(Console.ReadLine());
            int goalsMade = 0;
            int goalsReceived = 0;
            int goalsMadeTotal = 0;
            int goalsReceivedTotal = 0;

            int game = 0;
            int score = 0;
            int sumScore = 0;

            for (int i = 0; i < numPlays; i++)
            {
                goalsMade = int.Parse(Console.ReadLine());
                goalsMadeTotal = goalsMadeTotal + goalsMade;
                goalsReceived = int.Parse(Console.ReadLine());
                goalsReceivedTotal = goalsReceivedTotal + goalsReceived;

                game = goalsMade - goalsReceived;
                if (game > 0)
                {
                    score = 3;
                }
                else if (game == 0)
                {
                    score = 1;
                }
                else if (game < 0)
                {
                    score = 0;
                }
                sumScore = sumScore + score;
            }
            if (goalsMadeTotal >= goalsReceivedTotal)
            {
                Console.WriteLine($"{team} has finished the group phase with {sumScore} points.");
                Console.WriteLine($"Goal difference: {goalsMadeTotal - goalsReceivedTotal}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {goalsMadeTotal - goalsReceivedTotal}.");
            }
        }
    }
}
