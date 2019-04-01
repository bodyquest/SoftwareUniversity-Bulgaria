using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            //CALC volume of "n" beer kegs
            // input 3* n  LINES
            //each 3 lines hold inf for ONE keg

            int n = int.Parse(Console.ReadLine());
            double maxVolume = 0;
            string bestModel = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volumeTemp = Math.PI * radius * radius * height;


                if (volumeTemp > maxVolume)
                {
                    maxVolume = volumeTemp;
                    bestModel = model;
                }

            }

            Console.WriteLine(bestModel);
        }
    }
}
