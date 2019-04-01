using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floors; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floors || (i==floors && floors == 1))
                    {
                        Console.Write($"L{i}{j}");
                        if (j < rooms - 1)
                        {
                            Console.Write(" ");
                        }
                        if (j == rooms-1)
                        {
                            Console.WriteLine();
                        }
                    }
                    if (i %2 == 0 && i != floors)
                    {
                        Console.Write($"O{i}{j}");
                        if (j < rooms - 1)
                        {
                            Console.Write(" ");
                        }
                        if (j == rooms-1)
                        {
                            Console.WriteLine();
                        }
                    }
                    if (i % 2 != 0 && floors !=1 && i!= floors)
                    {
                        Console.Write($"A{i}{j}");
                        if (j < rooms - 1)
                        {
                            Console.Write(" ");
                        }
                        if (j == rooms-1)
                        {
                            Console.WriteLine();
                        }
                    }

                }
            }
        }
    }
}
