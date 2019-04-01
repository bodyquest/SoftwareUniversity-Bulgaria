using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    class Bus
    {
        static void Main(string[] args)
        {
            // Автобус кара по маршрут София - Бургас.
            // При тръгването си в автобуса има определен брой пътници.
            // На всяка спирка се качват и слизат определен брой пътници.
            // Броят на спирките се въвежда от конзолата.Също така, на всеки нечетен брой спирки се качват по двама проверяващи и слизат на четните спирки.

            //Напишете програма, която изчислява колко пътника ще има в автобуса когато стигне в Бургас.
            //Вход
            //Входът се чете от конзолата и съдържа:
            //•	На първия ред - броят пътници в автобуса при потеглянето му -цяло число в интервала[1... 100]
            //•	На втория ред - броят на спирките -цяло число в интервала[1…50]
            //•	На следващите редове(равни на броят на спирките * 2) - броя на пътниците, които слизат и броя на пътниците които се качват -цели числа в интервала[0…100]

            //Изход
            //  Да се отпечата на конзолата 1 ред:
            // "The final number of passengers is: {брой пътници при пристигането}."

            int passengerCount = int.Parse(Console.ReadLine());
            int busStopCount = int.Parse(Console.ReadLine());

            int outPassengers = 0;
            int inPassengers = 0;
            int sum = 0;
            int conductors = 0;

            for (int i = 1; i <= busStopCount * 2; i++)
            {
                var inOutPassengers = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    outPassengers += inOutPassengers;
                }
                else if (i % 2 == 0)
                {
                    inPassengers += inOutPassengers;
                }
                if (busStopCount % 2 == 0)
                {
                    conductors = 0;
                }
                else
                {
                    conductors = 2;
                }    
                sum = passengerCount - outPassengers + inPassengers + conductors;
            }
            Console.WriteLine($"The final number of passengers is : {sum}");

        }
    }
}
