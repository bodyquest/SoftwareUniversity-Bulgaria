using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            int sum = 0;
            while (true)
            {
                string input = Console.ReadLine();
                int steps = 0;
                
                if (int.TryParse(input, out steps))
                {
                    sum += steps;
                    if (sum >= 10_000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        return;
                    }
                }

                if (input == "Going home")
                {
                    steps = int.Parse(Console.ReadLine());
                    sum += steps;
                    if (sum < 10_000)
                    {
                        Console.WriteLine($"{10_000 - sum} more steps to reach goal.");
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                    return;
                }
            }
        }
    }
}
