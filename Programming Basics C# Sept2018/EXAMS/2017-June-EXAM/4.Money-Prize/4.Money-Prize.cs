using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Money_Prize
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            double prizePerPoint = double.Parse(Console.ReadLine());
            double sumPoints = 0;
            for (int part = 1; part <= parts; part++)
            {
                int points = int.Parse(Console.ReadLine());
                if (part%2 == 0)
                {
                    sumPoints += points * 2;
                }
                else if (part%2 !=0)
                {
                    sumPoints += points;
                }
            }
            Console.WriteLine($"The project prize was {sumPoints*prizePerPoint:f2} lv.");
        }
    }
}
