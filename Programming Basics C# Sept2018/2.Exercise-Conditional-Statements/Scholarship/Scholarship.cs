using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Scholarship
    {
        static void Main(string[] args)
        {
            // Учениците могат да кандидатстват за социална стипендия или за стипендия за отличен успех.
            // Изискване за социална стипендия -доход на член от семейството по - малък от минималната работна заплата и успех над 4.5.
            // Размер на социалната стипендия - 35 % от минималната работна заплата.Изискване за стипендия за отличен успех -успех над 5.5, включително.
            // Размер на стипендията за отличен успех -успехът на ученика, умножен по коефициент 25.
            // Напишете програма, която при въведени доход, успех и минимална работна заплата, дава информация дали ученик има право да получава стипендия,
            // и стойността на стипендията, която е по-висока за него.

            //Вход
            //Потребителят въвежда 3 числа, по едно на ред:
            //1.Доход в лева -реално число в интервала[0.00..6000.00]
            //2.Среден успех - реално число в интервала[2.00...6.00]
            //3.Минимална работна заплата -реално число в интервала[0.00..1000.00]

            //Изход
            //•	Ако ученикът няма право да получава стипендия, се извежда:
            //"You cannot get a scholarship!"
            //•	Ако ученикът има право да получава социална стипендия и тя е по-висока от стипендията за отличен успех:
            //            "You get a Social scholarship {стойност на стипендия} BGN"
            //•	Ако ученикът има право да получава стипендия за отличен успех и тя е по-висока или равна по стойност на социалната стипендия за него:
            //•	"You get a scholarship for excellent results {стойност на стипендията} BGN"

            //Резултатът се закръгля до по - малкото цяло число.

            double income = double.Parse(Console.ReadLine());
            double performance = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minSalary * 0.35);
            double performScholarship = Math.Floor(performance * 25);

            if ((performance >= 5.50 && performScholarship > socialScholarship) || (income >= minSalary && performance >= 5.50))
            {
                Console.WriteLine($"You get a scholarship for excellent results {performScholarship} BGN");
            }
            else if (performance > 4.50 && income < minSalary)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
