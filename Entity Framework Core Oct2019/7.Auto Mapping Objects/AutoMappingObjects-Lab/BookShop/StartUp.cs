namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Initializer;
    using BookShop.Data.ViewModels;
    using BookShop.Data.Models.Enums;

    using Newtonsoft.Json;
    using Z.EntityFramework.Plus;
    using AutoMapper;
    using AutoMapper.Collection;
    using AutoMapper.QueryableExtensions;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            //Run this method first in StartUp to seed, then comment to avoid reset
            //DbInitializer.ResetDatabase(context);
            //***************************************//
            //using var context = new BookShopContext();

            //Mapper.Initialize(cfg =>
            //{
            //    //cfg.CreateMap<Book, BookDTO>();
            //    //.ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            //    //cfg.CreateMap<BookDTO, Book>();
            //    //.ReverseMap(); allows to revers the mapping without .ForMember()

            //    cfg.CreateMap<Book, BookDTO>()
            //    .ReverseMap();
            //});

            // MANUAL MAPPING EXAMPLE
            //var books = context.Books
            //    .Select(b => new BookDTO() 
            //    {
            //        Title = b.Title,
            //        Price = b.Price,
            //        //Author = $"{b.Author.FirstName} {b.Author.LastName}"
            //    })
            //    .ToList();

            //string result = JsonConvert.SerializeObject(books, Formatting.Indented);
            //**************************************************//

            // INITIALIZATION OF AutoMapper
            ////////////////////////////////
            // Add mapping between object and DTO
            //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            //**************************************************//


            // MAPPING of properties by name
            ////////////////////////////////
            // var product = context.Products.FirstOrDefault();
            // ProductDTO dto = Mapper.Map<ProductDTO>(product);
            //**************************************************//


            // MAPPING configs can be done at once
            ////////////////////////////////
            // Mapper.Initialize(cfg =>
            // {
            //    cfg.CreateMap<Product, ProductDTO>();
            //    cfg.CreateMap<Order, OrderDTO>();
            //    cfg.CreateMap<Client, ClientDTO>();
            //    cfg.CreateMap<SupportTicket, TicketDTO>();
            // });


            //MAPPING Object To DTO EXAMPLE
            //FLATTENING Objects
            ////////////////////////////////
            ////////////////////////////////
            // 1. We get the object
            // 2. Map the DTO to the object
            // 3. Serialize the DTO and print it

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, BookDTO>()
            //    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            //});

            //var newBook = context.Books
            //    .Include(b => b.Author)
            //    .First();

            //var bookDto = Mapper.Map<BookDTO>(newBook);

            //string newResult = JsonConvert.SerializeObject(bookDto, Formatting.Indented);
            //Console.WriteLine(newResult);
            //**************************************************//

            //MAPPING DTO To Object EXAMPLE
            //UNFLATTENING Objects
            ////////////////////////////////
            ////////////////////////////////
            //Mapper.Initialize(cfg => cfg.CreateMap<BookDTO, Book>()
            //    .ReverseMap() //allows to reverse the mapping without .ForMember()
            //);

            //var bookDto = new BookDTO()
            //{
            //    Title = "Title",
            //    Price = 10m,
            //    AuthorFirstName = "Name"
            //};

            //var book = Mapper.Map<Book>(bookDto);

            //string newResult = JsonConvert.SerializeObject(book, Formatting.Indented);
            //Console.WriteLine(newResult);

            //**********************************************************************//

            // MAPPING Collections
            //Works like .Select()
            ////////////////////////////////
            ////////////////////////////////
            //var rposts = context.Posts
            //    .Where(p => p.Author.Username == "gosho")
            //    .ProjectTo<PostDto>()
            //    .ToArray();

            //using (var db = new BookShopContext())
            //{
            //    var books = db.Books
            //    .Where(b => b.EditionType == EditionType.Gold)
            //    .ToList();

            //    string output = JsonConvert.SerializeObject(books, Formatting.Indented);
            //    //Console.WriteLine(output);
            //}

            //With ProjectTo<>() Extension Method
            //using (var db = new BookShopContext())
            //{
            //    var books = db.Books
            //    .Where(b => b.EditionType == EditionType.Gold)
            //    .ProjectTo<BookDTO>()
            //    .ToList();

            //    string output = JsonConvert.SerializeObject(books, Formatting.Indented);
            //    //Console.WriteLine(output);
            //}

            //With manual .Select()
            //using (var db = new BookShopContext())
            //{
            //    var books = db.Books
            //    .Where(b => b.EditionType == EditionType.Gold)
            //    .Select(b => new BookDTO()
            //    {
            //        Title = b.Title,
            //        Price = b.Price
            //    })
            //    .ToList();

            //    string output = JsonConvert.SerializeObject(books, Formatting.Indented);
            //   //Console.WriteLine(output);
            //}

            // AutoMapper.Collection
            ////////////////////////////////////
            ////////////////////////////////////

            using (var db = new BookShopContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddCollectionMappers();
                    cfg.UseEntityFrameworkCoreModel<BookShopContext>();
                    //cfg.SetGeneratePropertyMaps
                    // <GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<BookShopContext>>();

                    cfg.CreateMap<Book, BookDTO>();
                    cfg.CreateMap<BookDTO, Book>()
                        .EqualityComparison((dto, o) => dto.BookId == o.BookId);
                });

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddCollectionMappers();
                    cfg.UseEntityFrameworkCoreModel<BookShopContext>();
                    cfg.CreateMap<Book, BookDTO>();
                    cfg.CreateMap<BookDTO, Book>()
                        .EqualityComparison((dto, o) => dto.BookId == o.BookId);
                });

                var mapper = config.CreateMapper();

                var book = db.Books.First(b => b.BookId == 1);

                var bookDto = new BookDTO()
                {
                    Title = "DtoTitle",
                    Price = 15m
                };

                db.Books.Persist(mapper).InsertOrUpdate<BookDTO>(bookDto);

                var changedBook = db.Books
                    .First(b => b.BookId == 1);

                var books = new List<Book>()
                {
                    new Book()
                    {
                        BookId = 1,
                        Title = "Lord of the Rings",
                        Price = 30
                    },

                    new Book()
                    {
                        BookId = 2,
                        Title = "The Hobbit",
                        Price = 10
                    }
                };

                var bookDtos = new List<BookDTO>()
                {
                    new BookDTO()
                    {
                        BookId = 1,
                        Title = "TitleLR"
                    },

                    new BookDTO()
                    {
                        BookId = 2,
                        Title = "TitleHB",
                        Price = 10
                    }
                };

                Mapper.Map(bookDtos, books);

                string output = JsonConvert.SerializeObject(book, Formatting.Indented);
                Console.WriteLine(output);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(JsonConvert.SerializeObject(changedBook, Formatting.Indented));
            }
        }
    }
}
