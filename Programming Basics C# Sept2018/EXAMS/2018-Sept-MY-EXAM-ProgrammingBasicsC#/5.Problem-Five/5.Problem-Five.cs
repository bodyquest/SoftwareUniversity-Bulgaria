using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Problem_Five
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double electro = 0;
            int water = 20;
            int www = 15;
            double other = 1.2 * (electro + water + www);
            double sumOther = 0;
            double sumElectro = 0;

            for (int numMonths = 1; numMonths <= months; numMonths++)
            {
                electro = double.Parse(Console.ReadLine());
                sumElectro += electro;
                other = (electro + water + www)*1.2;
                sumOther += other;
            }

            Console.WriteLine($"Electricity: {sumElectro:f2} lv");
            Console.WriteLine($"Water: {water*months:f2} lv");
            Console.WriteLine($"Internet: {www*months:f2} lv");
            Console.WriteLine($"Other: {sumOther:f2} lv");
            Console.WriteLine($"Average: {(sumElectro + sumOther + water*months + www*months)/months:f2} lv");
        }
    }
}
