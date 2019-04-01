using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfSeconds
{
    class SumOfSeconds
    {
        static void Main(string[] args)
        {
            int result1 = int.Parse(Console.ReadLine());
            int result2 = int.Parse(Console.ReadLine());
            int result3 = int.Parse(Console.ReadLine());

            int seconds = result1 + result2 + result3;
            int minutes = seconds / 60;
            if (seconds >= 0 && seconds <= 59)
            {
                minutes = 0;
            }
            if (seconds >= 60 && seconds <= 119)
            {
                minutes = 1;
                seconds = seconds % 60;
            }
            if (seconds >= 120 && seconds <= 179)
            {
                minutes = 2;
                seconds = seconds % 60;
            }
            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
