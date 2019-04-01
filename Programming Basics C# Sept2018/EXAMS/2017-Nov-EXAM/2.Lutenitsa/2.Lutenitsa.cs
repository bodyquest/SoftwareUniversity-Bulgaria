using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Lutenitsa
{
    class Program
    {
        static void Main(string[] args)
        {
            // В една оранжерия се отглеждат домати. От 5 килограма домати може да се получи 1 килограм лютеница, която се пълни в буркани, поемащи 535 грама готов продукт.
            // Един камион може да побере X касетки, като във всяка от тях има по Y буркана(X и Y се прочитат от входа).Да се напише програма, която пресмята какво количество лютеница може да се произведе и дали то е достатъчно да се напълни камионът. Ако е достатъчно, да се изведе колко буркана и касетки остават в излишък, ако не – колко не достигат за запълване на камиона.

            //Вход:
            //Входът се чете от конзолата и се състои от точно 3 реда:
            //            1.Количество домати в килограми – реално число в интервала[0.00... 100 000.00];
            //            2.Брой касетки – цяло число в интервала[100... 600];
            //            3.Брой буркана – цяло число в интервала[6... 40].

            //Изход:
            //            На конзолата трябва да се отпечата следното:
            //            o   "Total lutenica: {общо} kilograms."
            //•	Ако може да се напълни камионът:
            //o   "{Оставащи касетки} boxes left."
            //o   "{Оставащи буркани} jars left."
            //•	Ако не може да се напълни камионът:
            //            o   "{недостигащи касетки} more boxes needed."
            //o   "{недостигащи буркани} more jars needed."

            //Резултата да се закръгли към по-ниското цяло число!

            double tomatoes = double.Parse(Console.ReadLine());
            int crates = int.Parse(Console.ReadLine());
            int jars = int.Parse(Console.ReadLine());

            double totalJars = (double)(tomatoes / 5/0.535);
            double totalCrates = (double)(totalJars / 20);
            double leftCrates = 0;
            double leftJars = 0;


            Console.WriteLine($"Total lutenica: { tomatoes / 5} kilograms.");
            if (totalCrates >= crates)
            {
                leftCrates = Math.Floor(totalCrates - crates);
                leftJars = Math.Floor(totalJars - crates*jars);
                Console.WriteLine($"{leftCrates} boxes left.");
                Console.WriteLine($"{leftJars} jars left.");
            }
            else
            {
                leftCrates = Math.Floor(crates - totalCrates);
                leftJars = Math.Floor(jars - totalJars);
                Console.WriteLine($"{leftCrates} more boxes needed.");
                Console.WriteLine($"{leftJars} more jars needed.");
            }

        }
    }
}
