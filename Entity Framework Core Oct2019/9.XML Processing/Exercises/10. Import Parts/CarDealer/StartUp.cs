﻿namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Dtos.Import;

    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            Mapper.Initialize(cfg =>
                              cfg.AddProfile<CarDealerProfile>());

            using (var context = new CarDealerContext())
            {
                //9.
                //var xml = File.ReadAllText("./../../../Datasets/suppliers.xml");
                //var result = ImportSuppliers(context, xml);
                //Console.WriteLine(result);

                //10.
                var xml = File.ReadAllText("./../../../Datasets/parts.xml");
                var result = ImportParts(context, xml);
                Console.WriteLine(result);
            };
        }

        //9.
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportSupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            var supplierDtos = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //10.
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            var partsDtos = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            var validPartsDtos = partsDtos.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));
            var parts = Mapper.Map<Part[]>(validPartsDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }
    }
}