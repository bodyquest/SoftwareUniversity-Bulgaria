using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            var plates = Console.ReadLine().Split(", ").ToArray();

            while (plates[0].ToLower() != "end")
            {
                string direction = plates[0];
                string plate = plates[1];

                if (direction == "IN")
                {
                    cars.Add(plate);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(plate); 
                }

                plates = Console.ReadLine().Split(", ").ToArray();
            }

            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
