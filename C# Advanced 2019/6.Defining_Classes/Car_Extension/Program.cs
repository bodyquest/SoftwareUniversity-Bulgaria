using System;

namespace Car_Extension
{
    class Program
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(2000);
            Console.WriteLine(car.GetInformation());
        }
    }
}
