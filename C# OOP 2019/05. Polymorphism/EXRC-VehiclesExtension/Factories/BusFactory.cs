using EXRC_VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_VehiclesExtension.Factories
{
    public class BusFactory
    {
        public  Bus MakeBus()
        {
            string[] busData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busData[1]);
            double busFuelConsumption = double.Parse(busData[2]);
            int tankCapacity = int.Parse(busData[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, tankCapacity);

            return bus;
        }
    }
}
