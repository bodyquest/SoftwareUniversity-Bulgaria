namespace BookShop.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
