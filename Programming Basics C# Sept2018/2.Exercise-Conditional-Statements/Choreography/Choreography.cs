using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Choreography
    {
        static void Main(string[] args)
        {
            // Група танцьори се подготвя за финално състезание.Те трябва да научат нова хореография.
            // Танца се състои от N - на брой стъпки, които се разпределят между танцьорите. 
            // Цялата хореография трябва да се научи за определен брой дни. Всички танцьори могат да научат не повече от 13 % от общите стъпки на ден.
            // Да се напише програма която пресмята дали танцьорите ще успеят да научат новия танц и по колко процента от стъпките следва да научи всеки един от тях.

            //При изчисляване на процента стъпки на ден, числото трябва да се закръгли към най - близкото цяло число нагоре.

            //ВХОД
            //От конзолата се четат 3 реда:
            //            1.Брой стъпки - цяло число в интервала[1 … 100 000]
            //2.Брой танцьори - цяло число в интервала[1 … 50]
            //3.Брой дни за учене - цяло число в интервала[1 … 31]
            //ИЗХОД
            //Отпечатването на конзолата зависи от резултата:
            //•	Ако общия процент стъпки са по-малко или равни на 13 % отпечатваме:
            //o   "Yes, they will succeed in that goal! {процент стъпки които трябва да научи всеки един танцьор на ден}%."
            //•	Ако общия процент стъпки са повече от 13 % отпечатваме:
            //o   "No, They will not succeed in that goal! Required {процент стъпки, които трябва да научи всеки един танцьор на ден}% steps to be learned per day."

            //И двата отговора трябва да са форматирани до втория знак след десетичната запетая.

            double stepsCount = double.Parse(Console.ReadLine());
            double dancersCount = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            // 13% from steps per DAY
            // % /day Math.Ceiling

            double stepsPerDay = Math.Ceiling(stepsCount / days / stepsCount * 100);
            var stepsPerDancer = stepsPerDay / dancersCount;

            if (stepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPerDancer:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {stepsPerDancer:f2}% steps to be learned per day.");
            }
            





        }
    }
}
