namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var orderTypeEnum = Enum.Parse<OrderType>(orderType);

            var employee = context.Employees
                .ToArray()
                .Where(e => e.Name == employeeName)
                .Select(e => new
                {
                    Name = e.Name,
                    Orders = e.Orders
                        .Where(x => x.Type == orderTypeEnum)
                        .Select(c => new
                        {
                            Customer = c.Customer,
                            Items = c.OrderItems.Select(x => new
                            {
                                Name = x.Item.Name,
                                Price = x.Item.Price,
                                Quantity = x.Quantity
                            })
                            .ToArray(),
                            TotalPrice = c.TotalPrice
                        })
                        .OrderByDescending(x => x.TotalPrice)
                        .ThenByDescending(x => x.Items.Length)
                        .ToArray(),
                    TotalMade = e.Orders
                    .Where(x => x.Type == orderTypeEnum)
                    .Sum(x => x.TotalPrice)
                })
                .FirstOrDefault();
                

            var jsonSerialized = JsonConvert.SerializeObject(employee, Newtonsoft.Json.Formatting.Indented);

            return jsonSerialized;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var array = categoriesString.Split(',').ToArray();

            var categories = context.Categories
                .Where(c => array.Any(x => x == c.Name))
                .Select(x => new ExportCategoryDto 
                {
                    Name = x.Name,
                    MostPopularItem = x.Items
                    .Select(i => new MostPopularItemDto
                    {
                        Name= i.Name,
                        TimesSold = i.OrderItems.Sum(t => t.Quantity),
                        TotalMade = i.OrderItems.Sum(t => t.Item.Price * t.Quantity)
                    })
                    .OrderByDescending(c => c.TotalMade)
                    .ThenByDescending(c => c.TimesSold)
                    .FirstOrDefault()
                })
                .OrderByDescending(x => x.MostPopularItem.TotalMade)
                .ThenByDescending(x => x.MostPopularItem.TimesSold)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
	}
}