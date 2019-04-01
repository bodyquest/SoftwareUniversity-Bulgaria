using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int pieces = 0;
            int sumPieces = 0;
            int cakeSize = sideA * sideB;

            do
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out pieces))
                {
                    sumPieces += pieces;
                }
                if (input == "STOP")
                {
                    Console.WriteLine((cakeSize - sumPieces) + " pieces are left.");
                    break;
                }
                else if (sumPieces > cakeSize)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cakeSize - sumPieces)} pieces more.");
                }

            } while (sumPieces <= cakeSize);
        }
    }
}
