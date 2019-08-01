namespace EXRC_Vehicles.Factories
{
    using System;

    using EXRC_Vehicles.Models;

    public class TruckFactory
    {
        public Truck MakeTruck()
        {
            string[] truckData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckData[1]);
            double truckFuelConsumption = double.Parse(truckData[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            return truck;
        }
    }
}
