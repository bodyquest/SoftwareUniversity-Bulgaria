namespace EXRC_VehiclesExtension.Factories
{
    using System;

    using EXRC_VehiclesExtension.Models;

    public class CarFactory
    {
        public Car MakeCar()
        {
            string[] carData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carData[1]);
            double carFuelConsumption = double.Parse(carData[2]);
            int tankCapacity = int.Parse(carData[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption, tankCapacity);

            return car;
        }
    }
}
