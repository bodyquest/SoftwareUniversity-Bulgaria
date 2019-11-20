namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using CarDealer.Data;
    using CarDealer.Models;

    using AutoMapper;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            context.Database.EnsureCreated();

            var json = File.ReadAllText("../../../Datasets/suppliers.json");

            Console.WriteLine(ImportSuppliers(context, json));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
    }
}