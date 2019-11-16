namespace BookShop.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using BookShop.Data.Models.Enums;
    using System.Text.Json.Serialization;

    public class Book
    {
        public Book()
        {
            BookCategories = new List<BookCategory>();
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [JsonIgnore]
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
