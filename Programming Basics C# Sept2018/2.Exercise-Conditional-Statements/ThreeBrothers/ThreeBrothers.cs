using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBrothers
{
    class ThreeBrothers
    {
        static void Main(string[] args)
        {
            // Трима братя решили да изненадат баща си, като почистят заедно гаража му.Големият брат чисти сам за определени часове - А.
            // Средният брат чисти сам за В часа. По - малкият брат чисти сам за С часа. Бащата отива да лови риба и няма да го има D часа.
            //Напишете програма, която пресмята дали тримата братя могат да изчистят заедно гаража и да изненадат баща си или не.  
            //Към общото време за почистване се добавят 15 % за почивка.
            //Вход
            //Входът се чете от конзолата и се състои от 4 реда:
            //•	Времето на първият брат за чистене сам – реално число в интервала[0.00 … 99.00]
            //•	Времето на вторият брат за чистене сам - реално число в интервала[0.00 … 99.00]
            //•	Времето на третият брат за чистене сам - реално число в интервала[0.00 …99.00]
            //•	Времето за риболов на бащата - реално число в интервала[0.00 … 99.00]
            //Изход
            //На конзолата трябва да се отпечата два реда.
            //1.Времето за чистене и почивка, форматирано до втори знак: "Cleaning time: {Времето за чистене }"
            //2.Има ли изненада или не:
            //•	Ако братята СА изненадали бащата(time left > 0): "Yes, there is a surprise - time left -> {остатък} hours." - резултата трябва да е закръглен към по-малко цяло число(пр. 1.90-> 1).
            //•	Ако братята НЕ СА изненадали бащата: "No, there isn't a surprise - shortage of time -> {недостиг} hours." - резултата трябва да е закръглен към по-голямо цяло число(пр. 1.10-> 2).

            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());
            double C = double.Parse(Console.ReadLine());
            double D = double.Parse(Console.ReadLine());

            double cleanTime = 1 / (1 / A + 1 / B + 1 / C) + (1 / (1 / A + 1 / B + 1 / C)* 0.15) ;
            double timeLeft = D - cleanTime;

            Console.WriteLine($"Cleaning time: {cleanTime:f2}");

            if (timeLeft  > 0)
            {
                Console.WriteLine("Yes, there is a surprise - time left ->" + " " + Math.Floor(timeLeft) + " hours.");
            }
            else
            {
                Console.WriteLine("No, there isn't a surprise - shortage of time ->" + " " + Math.Ceiling(Math.Abs(timeLeft)) + " hours.");
            }
        }
    }
}
