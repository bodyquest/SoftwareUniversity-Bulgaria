using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisquitFactory
{
    class BisquitFactory
    {
        static void Main(string[] args)
        {
            int batches = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= batches; i++)
            {
                while (i <= batches)
                {
                    var input = (Console.ReadLine());
                    
                    if (input == "sugar" || input == "flour" || input == "eggs")
                    {
                        count++;
                    }
                    if (input == "Bake!")
                    {
                        if (count < 3)
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                            i -= 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Baking batch number {i}...");
                            count = 0;
                            break;
                        }
                    }
                }
            }
        }
    }
}
