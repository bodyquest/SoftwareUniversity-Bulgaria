using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StavriRakia
{
    class StavriRakia
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double rakiaQty = 0;
            double degrees = 0; 

            for (int i = 1; i <= days; i++)
            {
                double rakia = double.Parse(Console.ReadLine());
                double gradusNow = double.Parse(Console.ReadLine());

                rakiaQty += rakia;
                gradusNow*= rakia;
                degrees += gradusNow;
                
            }
            degrees = degrees/ rakiaQty;
            Console.WriteLine($"Liter: {rakiaQty:f2}");
            Console.WriteLine($"Degrees: {degrees:f2}");

            if (degrees < 38)
            {
                Console.WriteLine("Not good, you should be baking!");
            }
            else if (degrees >= 38 && degrees < 42)
            {
                Console.WriteLine("Super!");
            }
            else if (degrees >= 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
