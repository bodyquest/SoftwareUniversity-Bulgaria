namespace EXRC_Vehicles.Core
{
    using System;

    using EXRC_Vehicles.Factories;
    using EXRC_Vehicles.Models;

    public class Engine
    {
        private CarFactory carFactory;
        private TruckFactory truckFactory;

        public Engine()
        {
            carFactory = new CarFactory();
            truckFactory = new TruckFactory();
        }

        public void Run()
        {
            Car car = carFactory.MakeCar();
            Truck truck = truckFactory.MakeTruck();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandData = Console.ReadLine().Split();

                string commandType = commandData[0];
                string vehicleType = commandData[1];
                double number = double.Parse(commandData[2]);

                if (commandType.ToLower() == "drive")
                {
                    double distance = number;

                    if (vehicleType.ToLower() == "car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType.ToLower() == "truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (commandType.ToLower() == "refuel")
                {
                    double fuel = number;

                    if (vehicleType.ToLower() == "car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (vehicleType.ToLower() == "truck")
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
