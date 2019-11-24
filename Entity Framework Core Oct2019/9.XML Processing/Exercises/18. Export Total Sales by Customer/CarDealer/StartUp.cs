namespace CarDealer
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
    using System.Text;
    using System.Xml;
    using CarDealer.Dtos.Export;

    public class StartUp
    {
        public static void Main()
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var context = new CarDealerContext())
            {
                ////9.
                //var xml = File.ReadAllText("./../../../Datasets/suppliers.xml");
                //var result = ImportSuppliers(context, xml);
                //Console.WriteLine(result);

                ////10.
                //var xml = File.ReadAllText("./../../../Datasets/parts.xml");
                //var result = ImportParts(context, xml);
                //Console.WriteLine(result);

                ////11.
                //var xml = File.ReadAllText("./../../../Datasets/cars.xml");
                //var result = ImportCars(context, xml);
                //Console.WriteLine(result);

                ////12.
                //var xml = File.ReadAllText("./../../../Datasets/customers.xml");
                //var result = ImportCustomers(context, xml);
                //Console.WriteLine(result);

                ////13.
                //var xml = File.ReadAllText("./../../../Datasets/sales.xml");
                //var result = ImportSales(context, xml);
                //Console.WriteLine(result);

                ////14.
                //Console.WriteLine(GetCarsWithDistance(context));

                ////15. 
                //Console.WriteLine(GetCarsFromMakeBmw(context));

                ////16.
                //Console.WriteLine(GetLocalSuppliers(context));

                ////17.
                //Console.WriteLine(GetCarsWithTheirListOfParts(context));

                //18.
                Console.WriteLine(GetTotalSalesByCustomer(context));

                ////19.
                //Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

            return $"Successfully imported {suppliers.Length}";
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

            return $"Successfully imported {parts.Length}";
        }

        //11.
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportCarDto[]),
                new XmlRootAttribute("Cars"));

            var carsDto = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var carObj = Mapper.Map<Car>(car);
                var uniqueIds = car.Parts.PartId.Select(id => id.PartId).Distinct().ToList();

                foreach (var id in uniqueIds)
                {
                    if (context.Parts.Any(p => p.Id == id))
                    {
                        var partCar = new PartCar
                        {
                            CarId = carObj.Id,
                            PartId = id
                        };

                        carObj.PartCars.Add(partCar);
                    }
                }

                cars.Add(carObj);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12.
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            var customerDtos = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                var customerObj = Mapper.Map<Customer>(customerDto);
                customers.Add(customerObj);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //13.
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportSaleDto[]),
                new XmlRootAttribute("Sales"));

            var salesDtos = (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCarIds = new HashSet<int>(
                context.Cars
                .Select(c => c.Id));

            var sales = new List<Sale>();

            foreach (var saleDto in salesDtos)
            {
                bool isValid = validCarIds.Contains(saleDto.CarId);

                if (isValid)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //14.
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(p => p.TravelledDistance > 2000000)
                .Select(p => new ExportCarDto
                {
                    Make = p.Make,
                    Model = p.Model,
                    TravelledDistance = p.TravelledDistance
                })
                .OrderBy(p => p.Make)
                .ThenBy(p => p.Model)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //15.
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(p => p.Make == "BMW")
                .Select(p => new ExportCarBmwDto
                {
                    Id = p.Id,
                    Model = p.Model,
                    TravelledDistance = p.TravelledDistance
                })
                .OrderBy(p => p.Model)
                .ThenByDescending(p => p.TravelledDistance)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarBmwDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s =>
                new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(cp => new ExportPartDto
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price
                    })
                    .OrderByDescending(cp => cp.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerWithSalesDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CustomerWithSalesDto[]), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //19. TODO
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {


            return null;
        }
    }
}