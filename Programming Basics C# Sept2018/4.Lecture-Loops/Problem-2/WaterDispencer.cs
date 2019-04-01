using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int output = 0;
            int sum = 0;
            int count = 0;
            do
            {
                string button = Console.ReadLine();
                count++;
                if (button == "Easy")
                {
                    output = 50;
                }
                else if (button == "Medium")
                {
                    output = 100;
                }
                else if (button == "Hard")
                {
                    output = 200;
                }
                sum += output;
                if (sum > volume)
                {
                    Console.WriteLine($"{sum - volume}ml has been spilled.");
                    return;
                }
                else if (sum == volume)
                {
                    Console.WriteLine($"The dispencer has been tapped {} times.");
                    return;
                }

            } while (true);
            
        }
    }
}
