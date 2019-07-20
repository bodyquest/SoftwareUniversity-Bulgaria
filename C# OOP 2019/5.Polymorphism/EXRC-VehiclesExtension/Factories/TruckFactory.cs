namespace EXRC_VehiclesExtension.Factories
{
    using System;

    using EXRC_VehiclesExtension.Models;

    public class TruckFactory
    {
        public Truck MakeTruck()
        {
            string[] truckData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckData[1]);
            double truckFuelConsumption = double.Parse(truckData[2]);
            int tankCapacity = int.Parse(truckData[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, tankCapacity);

            return truck;
        }
    }
}
