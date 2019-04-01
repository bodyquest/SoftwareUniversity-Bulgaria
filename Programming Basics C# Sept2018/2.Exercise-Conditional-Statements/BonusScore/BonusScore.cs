using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            //            Дадено е цяло число -брой точки.Върху него се начисляват бонус точки по правилата, описани по - долу.Да се напише програма, която пресмята бонус точките за това число и общия брой точки с бонусите.
            //•	Ако числото е до 100 включително, бонус точките са 5.
            //•	Ако числото е по-голямо от 100, бонус точките са 20 % от числото.
            //•	Ако числото е по-голямо от 1000, бонус точките са 10 % от числото.
            //•	Допълнителни бонус точки(начисляват се отделно от предходните):
            //o За четно число  +1 т.
            //o За число, което завършва на 5  +2 т.

            double num = double.Parse(Console.ReadLine());
            double bonus = 0;
            double moreBonus = 0;

            if (num <= 100)
            {
                bonus = bonus + 5;
            }
            else if (num < 1000)
            {
                bonus = bonus + num * 0.2;
            }
            else if (num >= 1000)
            {
                bonus = bonus + num * 0.1;
            }

            if (num%2 == 0)
            {
                moreBonus = 1;
            }
            else if (num%5 == 0)
            {
                moreBonus = 2;
            }

            Console.WriteLine(bonus + moreBonus);
            Console.WriteLine(num + bonus + moreBonus);
        }
    }
}
