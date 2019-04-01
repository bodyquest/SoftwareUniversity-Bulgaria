using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningRig
{
    class MiningRig
    {
        static void Main(string[] args)
        {
            int vcPrice = int.Parse(Console.ReadLine());
            int connPrice = int.Parse(Console.ReadLine());
            decimal electricityPerDay = decimal.Parse(Console.ReadLine());
            decimal profitPerDay = decimal.Parse(Console.ReadLine());

            int machineCost = 13 * (vcPrice + connPrice) + 1000;
            decimal roi = profitPerDay - electricityPerDay;
            decimal roiPerDay = roi * 13;
            decimal finalROI = Math.Ceiling(machineCost / roiPerDay);

            Console.WriteLine(machineCost);
            Console.WriteLine(finalROI);


        }
    }
}
