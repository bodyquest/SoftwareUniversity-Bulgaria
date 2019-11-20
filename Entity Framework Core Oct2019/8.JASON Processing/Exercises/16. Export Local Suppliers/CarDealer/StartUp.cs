namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Globalization;
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

            //12. var json = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, json));

            //13. var json = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, json));

            //14. Console.WriteLine(GetOrderedCustomers(context));

            //15. Console.WriteLine(GetCarsFromMakeToyota(context));

            Console.WriteLine(GetLocalSuppliers(context));

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

        //13.
        public static string ImportSales (CarDealerContext context, string imputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(imputJson)
                .ToList();

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //14.
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new 
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver  = c.IsYoungDriver
                })
                .ToList();

            var jsonSerialized = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonSerialized;
        }

        //15.
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make =="Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            var jsonSerialized = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonSerialized;
        }

        //16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => 
                new 
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var jsonSerialized = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return jsonSerialized;
        }
    }
}