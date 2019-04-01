using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class AreaOfFigures
    {
        static void Main(string[] args)
        {
            //Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и пресмята лицето й.
            //Фигурите са четири вида: квадрат(square), правоъгълник(rectangle), кръг(circle) и триъгълник(triangle).
            //На първия ред на входа се чете вида на фигурата(square, rectangle, circle или triangle).

            //Ако фигурата е квадрат, на следващия ред се чете едно число -дължина на страната му.
            //Ако фигурата е правоъгълник, на следващите два реда четат две числа -дължините на страните му.
            //Ако фигурата е кръг, на следващия ред чете едно число - радиусът на кръга.
            //Ако фигурата е триъгълник, на следващите два реда четат две числа -дължината на страната му и дължината на височината към нея.

            //Резултатът да се закръгли до 3 цифри след десетичната точка.

            string figure = Console.ReadLine();
            double a = 1;
            double b = 1;
            double r = 1;
            double h = 1;

            if (figure == "square")
            {
                a = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a*a, 3));
            }
            if (figure == "rectangle")
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * b, 3));
            }
            if (figure == "circle")
            {
                r = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(Math.PI * r * r, 3));
            }
            if (figure == "triangle")
            {
                a = double.Parse(Console.ReadLine());
                h = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((a * h)/2, 3));
            }
        }
    }
}
