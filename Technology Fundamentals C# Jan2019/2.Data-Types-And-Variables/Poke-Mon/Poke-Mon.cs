using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int distM = int.Parse(Console.ReadLine());
            int exhaustY = int.Parse(Console.ReadLine());
            double origPowerN = powerN;

            int count = 0;
            while (powerN >= distM)
            {
                powerN -= distM;
                count++;
                if (powerN == origPowerN * 0.5 && exhaustY > 0 )
                {
                    powerN /= exhaustY;
                }
                if (powerN < distM)
                {
                    break;
                }

            }

            Console.WriteLine(powerN);
            Console.WriteLine(count);

        }
    }
}
