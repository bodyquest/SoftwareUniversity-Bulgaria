using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    class Shopping
    {
        static void Main(string[] args)
        {
            // Иво има определен бюджет и с него трябва да купи няколко неща от магазина. 
            //Той има нужда от твоята помощ за написването на програма, която да изчисли дали наличната му сума ще е достатъчна за да купи всичко в списъка.

            //Първото нещо, което той трябва да закупи е N шоколадчета, по 65ст.всяко,
            //второто - M литра мляко по 2.70лв за литър и 35 % по - малко броя мандарини от броя на шоколадите, като се има в предвид, че една мандарина струва 20ст.
            //Да се изчисли дали Иво ще успее да закупи плануваните неща и ако успее колко пари са му останали, ако парите не му стигат, да се изчисли колко пари не му достигат.

            //Вход
            //Входът се чете от конзолата и съдържа точно 3 реда:
            //•	На първия ред е бюджетът на Иво – реално число в интервала[0.0..100000.0]
            //•	На втория ред е броят шоколади -цяло число в интервала[0...999]
            //•	На третия ред е количеството мляко – реално число в интервала[0.0...50.0]

            //Изход
            //На конзолата се отпечатва 1 ред, който изглежда по следния начин:
            //•	Ако сумата пари след пазара е повече или равна на бюджета:
            //            "You got this, {останали пари} money left!"
            //•	Ако сумата пари след пазара е по - малко от бюджета:
            //"Not enough money, you need {пари} more!"
            //Резултатът да се форматира до втория знак след десетичната запетая.

            double budget = double.Parse(Console.ReadLine());
            int choc = int.Parse(Console.ReadLine());
            double milk = double.Parse(Console.ReadLine());
            double mandarines = Math.Floor(choc - choc * 0.35);

            double chocPrice = 0.65;
            double milkPrice = 2.7;
            double mandPrice = 0.20;
            double grocery = choc * chocPrice + milk * milkPrice + mandarines * mandPrice;

            if (budget >= grocery)
            {
                Console.WriteLine($"You got this, {budget - grocery:f2} money left!");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {grocery - budget:f2} more!");
            }

        }
    }
}
