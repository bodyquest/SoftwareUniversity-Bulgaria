using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма, която преобразува разстояние между следните 8 мерни единици: m, mm, cm, mi, in, km, ft, yd.Използвайте съответствията от таблицата по - долу:
            //входна единица  изходна единица
            //1 meter(m) 1000 millimeters(mm)
            //1 meter(m) 100 centimeters(cm)
            //1 meter(m) 0.000621371192 miles(mi)
            //1 meter(m) 39.3700787 inches(in)
            //1 meter(m) 0.001 kilometers(km)
            //1 meter(m) 3.2808399 feet(ft)
            //1 meter(m) 1.0936133 yards(yd)

            //Входните данни се състоят от три реда, въведени от потребителя:
            //•	Първи ред: число за преобразуване – реално число 
            //•	Втори ред: входна мерна единица - текст
            //•	Трети ред: изходна мерна единица(за резултата) – текст
            //На конзолата да се отпечата резултатът от преобразуването на мерните единици форматиран до осмия знак след десетичната запетая.

            double distance = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "mm")
            {
                distance = distance / 1000;
            }
            else if ((inputUnit == "cm"))
            {
                distance = distance / 100;
            }
            else if ((inputUnit == "mi"))
            {
                distance = distance / 0.000621371192;
            }
            else if ((inputUnit == "in"))
            {
                distance = distance / 39.3700787;
            }
            else if ((inputUnit == "km"))
            {
                distance = distance / 0.001;
            }
            else if ((inputUnit == "ft"))
            {
                distance = distance / 3.2808399;
            }
            else if ((inputUnit == "yd"))
            {
                distance = distance / 1.0936133;
            }

            if (outputUnit == "mm")
            {
                distance = distance * 1000;
            }
            else if ((outputUnit == "cm"))
            {
                distance = distance * 100;
            }
            else if ((outputUnit == "mi"))
            {
                distance = distance * 0.000621371192;
            }
            else if ((outputUnit == "in"))
            {
                distance = distance * 39.3700787;
            }
            else if ((outputUnit == "km"))
            {
                distance = distance * 0.001;
            }
            else if (outputUnit == "ft")
            {
                distance = distance * 3.2808399;
            }
            else if ((outputUnit == "yd"))
            {
                distance = distance * 1.0936133;
            }

            Console.WriteLine($"{distance:f8}");
        }
    }
}
