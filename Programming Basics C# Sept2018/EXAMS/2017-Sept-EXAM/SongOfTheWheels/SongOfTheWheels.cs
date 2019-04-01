using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongOfTheWheels
{
    class SongOfTheWheels
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 0;
            StringBuilder password = new StringBuilder();

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (num == a * b + c * d && a < b && c > d)
                            {
                                count++;
                                Console.Write($"{a}{b}{c}{d} ");
                                if (count == 4)
                                {
                                    password.Append($"{a}{b}{c}{d}");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            if (count < 4)
            {
                Console.WriteLine("No!");
            }
            else
            {
                Console.WriteLine($"Password: {password}");
            }
        }
    }
}
