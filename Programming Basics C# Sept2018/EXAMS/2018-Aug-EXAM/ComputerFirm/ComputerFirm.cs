using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerFirm
{
    class ComputerFirm
    {
        static void Main(string[] args)
        {
            int computerCount = int.Parse(Console.ReadLine());
            double rating = 0;
            double sales = 1;
            double avgSales = 0;

            for (int i = 0; i < computerCount; i++)
            {
                double num = 1;
                double salesAndRating = double.Parse(Console.ReadLine());
                sales = Math.Floor(salesAndRating / 10);
                num = salesAndRating % 10;
                
                if (num == 2)
                {
                    sales = 0;
                }
                else if (num == 3)
                {
                    sales = sales * 0.5;
                }
                else if (num == 4)
                {
                    sales = sales * 0.7;
                }
                else if (num == 5)
                {
                    sales = sales * 0.85;
                }
                else if (num == 6)
                {
                    sales = sales * 1.0;
                }

                rating = rating + num;
                avgSales = avgSales + sales;
            }
            Console.WriteLine($"{avgSales:f2}");
            Console.WriteLine($"{rating / computerCount:f2}");
        }
    }
}
