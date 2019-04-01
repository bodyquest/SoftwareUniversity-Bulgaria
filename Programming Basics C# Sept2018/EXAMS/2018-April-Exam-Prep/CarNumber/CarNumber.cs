using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumber
{
    class CarNumber
    {
        static void Main(string[] args)
        {
            int startOfRange = int.Parse(Console.ReadLine());
            int endOfRange = int.Parse(Console.ReadLine());

            for (int num1 = startOfRange; num1 <= endOfRange; num1++)
            {
                for (int num2 = startOfRange; num2 <= endOfRange; num2++)
                {
                    for (int num3 = startOfRange; num3 <= endOfRange; num3++)
                    {
                        for (int num4 = startOfRange; num4 <= endOfRange; num4++)
                        {
                            if (((num1 %2 == 0 && num4 % 2 != 0)||(num4 % 2 == 0 && num1 % 2 != 0)) && num1 > num4 && ((num2 + num3)%2 == 0))
                            {
                                Console.WriteLine($"{num1} {num2} {num3} {num4}");
                            }
                            
                        }
                    }
                }
            }

        }
    }
}
