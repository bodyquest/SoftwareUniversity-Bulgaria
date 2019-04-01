using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRecord
{
    class WorldRecord
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double idealSwimTime = distance * time;
            double dragTime = Math.Floor(distance / 15) * 12.5;
            double swimTime = idealSwimTime + dragTime;

            if (swimTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {swimTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine(value: "No, he failed! He was " + $"{swimTime - record:f2}" + " seconds slower.");
            }
        }
    }
}
