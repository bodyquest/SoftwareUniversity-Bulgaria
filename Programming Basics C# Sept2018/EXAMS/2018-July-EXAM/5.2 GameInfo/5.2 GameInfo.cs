using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2_GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int numGames = int.Parse(Console.ReadLine());
            double playTime = 0;
            double totalPlayTime = 0;
            double avgPlayTime = 0;
            int penalties = 0;
            int longGames = 0;

            for (int i = 1; i <= numGames; i++)
            {
                playTime = int.Parse(Console.ReadLine());
                totalPlayTime = totalPlayTime + playTime;
                if (playTime > 90 && playTime <=120)
                {
                    longGames +=1;
                }
                if (playTime > 120)
                {
                    penalties += 1;  
                }
            }
            avgPlayTime = totalPlayTime / numGames;
            Console.WriteLine($"{team} has played {totalPlayTime} minutes. Average minutes per game: {avgPlayTime:f2}");
            Console.WriteLine($"Games with penalties: {penalties}");
            Console.WriteLine($"Games with additional time: {longGames}");
        }
    }
}
