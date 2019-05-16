using System;
using System.Collections.Generic;
using System.Linq;

namespace Auto_Repair_And_Service
{
    public class Program
    {
        static void Main()
        {
            var carModels = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> queueOfCars = new Queue<string>(carModels);
            Stack<string> servedCars = new Stack<string>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var carInfo = input.Split("-");
                if (input == "Service" && queueOfCars.Count != 0)
                {
                    string currentCar = queueOfCars.Dequeue();
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                }
                else if (input == "History")
                {
                    var served = servedCars.ToList();
                    Console.WriteLine(string.Join(", ", served));
                }
                else if (carInfo[0] == "CarInfo")
                {
                    string model = carInfo[1];
                    if (queueOfCars.Contains(model))
                    {
                        Console.WriteLine("Still waiting for service.");

                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                input = Console.ReadLine();
            }

            if (queueOfCars.Count > 0)
            {
                Console.Write("Vehicles for service: ");
                var queue = queueOfCars.ToList();
                Console.WriteLine(string.Join(", ", queue));
            }

            Console.Write("Served vehicles: ");
            var stack = servedCars.ToList();
            Console.WriteLine(string.Join(", ", stack));
            Console.WriteLine();
        }
    }
}