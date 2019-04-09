using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Catalogue
{
    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var carCatalogue = new List<Car>();
            var truckCatalogue = new List<Truck>();

            while (input[0] != "End")
            {
                string type = input[0].ToLower();
                string model = input[1];
                string color = input[2];
                int hp = int.Parse(input[3]);

                if (type.Equals("car"))
                {
                    Car newCar = new Car();
                    newCar.Model = model;
                    newCar.Color = color;
                    newCar.Horsepower = hp;
                    carCatalogue.Add(newCar);
                }
                else if (type.Equals("truck"))
                {
                    Truck newTruck = new Truck();
                    newTruck.Model = model;
                    newTruck.Color = color;
                    newTruck.Horsepower = hp;
                    truckCatalogue.Add(newTruck);
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            string info = Console.ReadLine();
            while (!info.Equals("Close the Catalogue"))
            {
                if (carCatalogue.Select(x => x.Model).Contains(info))
                {
                    foreach (var car in carCatalogue)
                    {
                        if (car.Model == info)
                        {
                            Console.WriteLine($"Type: Car\r\nModel: {car.Model}\r\nColor: {car.Color}\r\nHorsepower: {car.Horsepower}");
                        }
                    }
                }
                else if (truckCatalogue.Select(x => x.Model).Contains(info))
                {
                    foreach (var truck in truckCatalogue)
                    {
                        if (truck.Model == info)
                        {
                            Console.WriteLine($"Type: Truck\r\nModel: {truck.Model}\r\nColor: {truck.Color}\r\nHorsepower: {truck.Horsepower}");
                        }
                    }
                }

                info = Console.ReadLine();
            }

            double avgHpCars = carCatalogue.Count > 0 ? carCatalogue.Average(x => x.Horsepower) : 0.0;
            double avgHpTrucks = truckCatalogue.Count > 0 ? truckCatalogue.Average(x => x.Horsepower) : 0.0;

            Console.WriteLine($"Cars have average horsepower of: {avgHpCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgHpTrucks:f2}.");
        }
    }
}
