namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using CarDealer.DTO;
    using CarDealer.Data;
    using CarDealer.Models;

    using AutoMapper;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //9. var json = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, json));

            //10. var json = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, json));

            //11.var json = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, json));

            var json = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(context, json));

        }

        //9.
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //10.
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //11.
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson).ToList();

            var carsList = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in cars)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

                carsList.Add(car);
            }


            context.Cars.AddRange(carsList);
            context.PartCars.AddRange(carParts);

            context.SaveChanges();


            return $"Successfully imported {cars.Count}.";
        }

        //12.
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson).ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();


            return $"Successfully imported {customers.Count}.";
        }
    }
}