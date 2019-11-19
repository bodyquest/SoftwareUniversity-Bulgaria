namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;

    using Newtonsoft.Json;
    using ProductShop.DTOs.Export;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //1. var inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //2.var inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, inputJson));

            //3. var inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, inputJson));

            //4. var inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));

            //5. Console.WriteLine(GetProductsInRange(context));

            Console.WriteLine(GetSoldProducts(context));

            
        }

        //1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson)
                .Where(u => !string.IsNullOrEmpty(u.LastName) && u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson)
               .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
               .ToList();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
               .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3 && p.Name.Length <= 15)
               .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validCategoryIds = new HashSet<int>(
                context.Categories
                .Select(c => c.Id));

            var validProductIds = new HashSet<int>(
                context.Products
                .Select(p => p.Id));

            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson)
               .ToList();
            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoryProducts)
            {
                bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) && validProductIds.Contains(categoryProduct.ProductId);

                if (isValid)
                {
                    validEntities.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validEntities);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => 
                    new ProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Seller = p.Seller.FirstName == null 
                        ? p.Seller.LastName 
                        : $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonSerialized = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonSerialized;
        }

        //6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                            BuyerFirstName = ps.Buyer.FirstName,
                            BuyerLastName = ps.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(users, 
                new JsonSerializerSettings 
                { 
                    Formatting = Formatting.Indented,
                    ContractResolver = resolver
                });

            return json;
        }

        
    }
}