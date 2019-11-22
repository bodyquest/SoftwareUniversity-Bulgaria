namespace ProductShop
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;

    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                ////1.
                //string xml1 = File.ReadAllText("./../../../Datasets/users.xml");
                //Console.WriteLine(ImportUsers(context, xml1));

                ////2.
                //string xml2 = File.ReadAllText("./../../../Datasets/products.xml");
                //Console.WriteLine(ImportProducts(context, xml2));

                ////3.
                //string xml3 = File.ReadAllText("./../../../Datasets/categories.xml");
                //Console.WriteLine(ImportCategories(context, xml3));

                ////4.
                //string xml4 = File.ReadAllText("./../../../Datasets/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(context, xml4));

                //5.
                Console.WriteLine(GetProductsInRange(context));


            };
        }

        //1.
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportUserDto[]),
                new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //2.
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProductDto[]),
                new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //3.
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportCategoryDto[]),
                new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //4.
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));

            var validCategoryIds = new HashSet<int>(
                context.Categories
                .Select(c => c.Id));

            var validProductIds = new HashSet<int>(
                context.Products
                .Select(p => p.Id));

            var categoryProductsDtos = (ImportCategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoryProductsDtos)
            {
                bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) && validProductIds.Contains(categoryProduct.ProductId);

                if (isValid)
                {
                    var categoryProductObj = Mapper.Map<CategoryProduct>(categoryProduct);
                    validEntities.Add(categoryProductObj);
                }
            }

            context.CategoryProducts.AddRange(validEntities);
            context.SaveChanges();

            return $"Successfully imported {validEntities.Count}";
        }

        //5.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] 
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}