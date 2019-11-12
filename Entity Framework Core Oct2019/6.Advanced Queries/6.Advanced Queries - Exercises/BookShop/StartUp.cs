namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main() 
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);

                //string command = Console.ReadLine();
                string result = GetBooksByAgeRestriction(context, "mInor");

                Console.WriteLine(result);
            }
        }

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

            //StringBuilder sb = new StringBuilder();

            //var bookTitles = context.Books
            //    .Where(b => b.AgeRestriction.ToString() == command.ToLower())
            //    .Select(b => new
            //    {
            //        b.Title
            //    })
            //    .OrderBy(b => b.Title)
            //    .ToList();

            //foreach (var bookTitle in bookTitles)
            //{
            //    sb.AppendLine(bookTitle.Title);
            //}

            //return sb.ToString().TrimEnd();
        }
    }
}
