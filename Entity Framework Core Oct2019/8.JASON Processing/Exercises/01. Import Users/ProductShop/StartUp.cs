namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;

    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            context.Database.EnsureCreated();

            var inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            Console.WriteLine(ImportUsers(context, inputJson));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}