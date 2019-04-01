using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lily
{
    class Lily
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            decimal cost = decimal.Parse(Console.ReadLine());
            decimal costToy = decimal.Parse(Console.ReadLine());
            decimal savings = 0m;
            decimal birthdayMoney = 10m;
            int brotherTaheft = -1;
            

            for (int i = 1; i <= age; i++)
            {
                if (i%2 !=0)
                {
                    savings += costToy;
                }
                else
                {
                    savings += birthdayMoney+brotherTaheft;
                    birthdayMoney += 10;
                }
            }
            if (savings >= cost)
            {
                Console.WriteLine($"Yes! {savings - cost:f2}");
            }
            else
            {
                Console.WriteLine($"No! {cost-savings:f2}");
            }
        }
    }
}
