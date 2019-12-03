namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
             //1. Deserialize to DTO
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var sb = new StringBuilder();
            var validEmployees = new List<Employee>();

            //2. Validation Check
            foreach (var dto in employeeDtos)
            {
                var isValid = IsValid(dto);

                var position = context.Positions.FirstOrDefault(p => p.Name == dto.Position);

                if (isValid)
                {
                    if (position == null)
                    {
                        position = new Position
                        {
                            Name = dto.Position
                        };

                        context.Positions.Add(position);
                        context.SaveChanges();
                    }

                    var employee = new Employee
                    {
                        Name = dto.Name,
                        Position = position,
                        Age = dto.Age
                    };

                    validEmployees.Add(employee);
                    sb.AppendLine(string.Format(SuccessMessage, dto.Name));
                }
                else
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
            }

            //3. Add In Database
            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            //1. Deserialize to DTO
            var itemDtos = JsonConvert.DeserializeObject<ImportItemDto[]>(jsonString);

            var sb = new StringBuilder();
            var validItems = new List<Item>();

            //2. Validation Check
            foreach (var dto in itemDtos)
            {
                var isValid = IsValid(dto);

                var itemToCheckName = validItems.Any(i => i.Name == dto.Name);

                var category = context.Categories.FirstOrDefault(c => c.Name == dto.Category);

                if (isValid)
                {
                    if (itemToCheckName)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }

                    if (category == null)
                    {
                        category = new Category
                        {
                            Name = dto.Category
                        };

                        context.Categories.Add(category);
                        context.SaveChanges();
                    }

                    var item = new Item
                    {
                        Name = dto.Name,
                        Price = dto.Price,
                        Category = category
                    };

                    validItems.Add(item);
                    sb.AppendLine(string.Format(SuccessMessage, dto.Name));
                }
                else
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
            }

            //3. Add In Database
            context.Items.AddRange(validItems);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            //1. Call the serializer
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportOrderDto[]),
                new XmlRootAttribute("Orders"));

            //2. Deserialize
            var orderDtos = (ImportOrderDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var orders = new List<Order>();
            var orderItems = new List<OrderItem>();

            //3. Go through each DTO object
            foreach (var dto in orderDtos)
            {
                //4. Validate each orderDTO
                if (!IsValid(dto))
                {
                    continue;
                }

                //5. Validate enum
                var isValidEnum = Enum.TryParse<OrderType>(dto.Type, out OrderType orderType);

                if (!isValidEnum)
                {
                    continue;
                }

                //6. Validate Employee if exists
                var employee = context.Employees.FirstOrDefault(e => e.Name == dto.Employee);
                if (employee == null)
                {
                    continue;
                }

                //7. Validate Items if exist
                var items = context.Items.Select(x => x.Name).ToArray();

                foreach (var item in dto.ItemDtos)
                {
                    if (!items.Contains(item.Name))
                    {
                        break;
                    }
                }

                //8. Create the Order object
                var date = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var order = new Order
                {
                    Customer = dto.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = orderType,
                };

                foreach (var item in dto.ItemDtos)
                {
                    var itemToValidate = context.Items.FirstOrDefault(x => x.Name == item.Name);

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        Item = itemToValidate,
                        Quantity = item.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                //9. Add to the collection
                orders.Add(order);
                
                sb.AppendLine($"Order for {order.Customer} on {date.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            //10. Add the collection of Orders in the Database
            context.Orders.AddRange(orders);
            context.SaveChanges();

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}