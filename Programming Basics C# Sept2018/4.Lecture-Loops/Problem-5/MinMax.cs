using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            var input = String.Empty;
            var max = int.MinValue;
            var min = int.MaxValue;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out num))
                {
                    if (num > max)
                    {
                        max = num;
                    }
                    else if(num < min)
                    {
                        min = num;
                    }
                }
                else if (input == "END")
                {
                    Console.WriteLine($"Max number: {max}");
                    Console.WriteLine($"Min number: {min}");
                    Console.WriteLine();
                    return;
                }
            } while (true) ;
            
        }
    }
}
