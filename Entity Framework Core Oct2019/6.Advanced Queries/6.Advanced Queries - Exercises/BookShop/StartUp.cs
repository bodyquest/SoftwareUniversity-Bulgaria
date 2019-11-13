namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Initializer;
    using BookShop.Data.Models.Enums;

    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //Run this method first in StartUp to seed, then comment to avoid reset
            //DbInitializer.ResetDatabase(context);
            //***************************************//

            //.1 string command = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(context, command);

            //.2 string result = GetGoldenBooks(context);

            //.3 string result = GetBooksByPrice(context);

            //.4 int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(context, year);

            //.5 string input = Console.ReadLine();
            //string result = GetBooksByCategory(context, input);

            //.6 string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(context, date);

            //.7 string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(context, input);

            //.8 string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(context, input);

            //.9 string input = Console.ReadLine();
            //string result = GetBooksByAuthor(context, input);

            //.10 int input = int.Parse(Console.ReadLine());
            //int result = CountBooks(context, input);

            //.11 string result = CountCopiesByAuthor(context);

            //.12 string result = GetTotalProfitByCategory(context);

            //.13 string result = GetMostRecentBooks(context);

            //.14 IncreasePrices(context);

            //.15 int result = RemoveBooks(context);


            //Console.WriteLine(result);

        }

        //#1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(a => a.AgeRestriction == ageRestriction)
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //#2
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEdition = Enum.Parse<EditionType>("Gold", true);
            var goldenBooks = context
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType == goldenEdition)
                .OrderBy(x => x.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        //#3
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();


            return string.Join(Environment.NewLine, booksByPrice.Select(b => $"{b.Title} - ${b.Price:F2}"));
        }

        //#4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotInYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksNotInYear);
        }

        //#5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var array = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var booksByCategory = context
                .Books
                .Where(bc => bc.BookCategories.Any(c => array.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, booksByCategory);
        }

        //#6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < targetDate)
                .OrderByDescending(x => x.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType.ToString()} - ${b.Price:F2}"));
        }

        //#7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(b => EF.Functions.Like(b.FirstName, $"%{input}"))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }

        //#8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.Contains(input))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //#9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName, $"{input}%"))
                .OrderBy(x => x.BookId)
                .Select(b => new
                {
                    b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.FullName})"));
        }

        //#10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.BookId)
                .ToList();

            return books.Count();
        }

        //#11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(b => new
                {
                    b.FirstName,
                    b.LastName,
                    BooksCount = b.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.BooksCount);


            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName} - {a.BooksCount}"));
        }

        //#12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var booksProfitByCategory = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b =>
                        b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ToList();

            return string.Join(Environment.NewLine, booksProfitByCategory
                .Select(p => $"{p.Name} ${p.Profit:F2}"));
        }

        //#13 TODO OPTIMIZE TO make only one query to DB
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostResentBooks = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    })
                    .Take(3) // Take() creates multiple queries to DB
                    .ToList()

                })
                .OrderBy(b => b.Category)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var category in mostResentBooks)
            {
                sb.AppendLine($"--{category.Category}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //#14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .Update( b => new Book() { Price = b.Price + 5});

            context.SaveChanges();
        }

        //#15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return books;
        }
    }
}
