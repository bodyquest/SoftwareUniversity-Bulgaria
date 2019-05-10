using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Speed_Racing
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carsList = new List<Car>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                string model = array[0];
                double fuelAmmount = double.Parse(array[1]);
                double fuelConsumption = double.Parse(array[2]);
                var car = new Car();
                car.Model = model;
                car.FuelAmount = fuelAmmount;
                car.FuelConsumption = fuelConsumption;
                carsList.Add(car);
            }

            var input = Console.ReadLine().Split(' ').ToArray();
            while (input[0] != "End")
            {
                string command = input[0];
                string model = input[1];
                double amountOfKilometers = double.Parse(input[2]);

                var currentCar = carsList.FirstOrDefault(c => c.Model == model);
                if (!Car.canDrive(currentCar, amountOfKilometers))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            carsList
                .ToList()
                .ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}
