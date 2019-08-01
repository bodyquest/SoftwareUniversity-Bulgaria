namespace EXRC_VehiclesExtension.Core
{
    using System;

    using EXRC_VehiclesExtension.Factories;
    using EXRC_VehiclesExtension.Models;

    public class Engine
    {
        private CarFactory carFactory;
        private TruckFactory truckFactory;
        private BusFactory busFactory;

        public Engine()
        {
            carFactory = new CarFactory();
            truckFactory = new TruckFactory();
            busFactory = new BusFactory();
        }

        public void Run()
        {
            Car car = carFactory.MakeCar();
            Truck truck = truckFactory.MakeTruck();
            Bus bus = busFactory.MakeBus();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandData = Console.ReadLine().Split();

                string commandType = commandData[0];
                string vehicleType = commandData[1];

                if (commandType.ToLower() == "drive")
                {
                    double distance = double.Parse(commandData[2]); ;

                    if (vehicleType.ToLower() == "car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType.ToLower() == "truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (vehicleType.ToLower() == "bus")
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (commandType.ToLower() == "refuel")
                {
                    double fuel = double.Parse(commandData[2]); ;

                    try
                    {
                        if (vehicleType.ToLower() == "car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (vehicleType.ToLower() == "truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else if (vehicleType.ToLower() == "bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    double distance = double.Parse(commandData[2]); ;

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
