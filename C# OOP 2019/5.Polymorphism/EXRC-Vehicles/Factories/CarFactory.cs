namespace EXRC_Vehicles.Factories
{
    using System;

    using EXRC_Vehicles.Models;

    public class CarFactory
    {
        public Car MakeCar()
        {
            string[] carData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carData[1]);
            double carFuelConsumption = double.Parse(carData[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            return car;
        }
    }
}
