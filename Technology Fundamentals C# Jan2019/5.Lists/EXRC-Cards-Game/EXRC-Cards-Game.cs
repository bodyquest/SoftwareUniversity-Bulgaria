using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var hand1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var hand2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (hand1.Count != 0 && hand2.Count != 0)
            {
                if (hand1[0] > hand2[0])
                {
                    hand1.Add(hand1[0]);
                    hand1.Add(hand2[0]);
                    hand1.Remove(hand1[0]);
                    hand2.Remove(hand2[0]);
                }
                else if (hand2[0] > hand1[0])
                {
                    hand2.Add(hand2[0]);
                    hand2.Add(hand1[0]);
                    hand1.Remove(hand1[0]);
                    hand2.Remove(hand2[0]);
                }
                else if (hand1[0] == hand2[0])
                {
                    hand1.Remove(hand1[0]);
                    hand2.Remove(hand2[0]);
                }
            }

            if (hand1.Count > 0)
            {
                int sum = hand1.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (hand2.Count > 0)
            {
                int sum = hand2.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
