using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Problem_Six
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int countFirstSector = int.Parse(Console.ReadLine());
            int countEvenSeats = int.Parse(Console.ReadLine());
            int count = 0;
            int countAllSeats = 0;

            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                
                for (int row = 1; row <=countFirstSector+ count; row++)
                {
                    if (row %2 != 0)
                    {
                        for (char seats = 'a'; seats < 'a' + countEvenSeats; seats++)
                        {
                            Console.WriteLine($"{sector}{row}{seats}");
                            countAllSeats++;
                        }
                    }
                    else if (row % 2 ==0)
                    {
                        for (char seats = 'a'; seats < 'a' + countEvenSeats + 2; seats++)
                        {
                            Console.WriteLine($"{sector}{row}{seats}");
                            countAllSeats++;
                        }
                    }
                }
                count++;
            }
            Console.WriteLine(countAllSeats);
        }
    }
}
