namespace BookShop.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
