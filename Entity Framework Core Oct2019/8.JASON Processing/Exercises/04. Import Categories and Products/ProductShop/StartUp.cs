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

            //1. var inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //2. var inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, inputJson));

            //3. var inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, inputJson));

            var inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, inputJson));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson)
                .Where(u => !string.IsNullOrEmpty(u.LastName) && u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson)
               .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
               .ToList();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
               .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3 && p.Name.Length <= 15)
               .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson)
               .ToList();

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}