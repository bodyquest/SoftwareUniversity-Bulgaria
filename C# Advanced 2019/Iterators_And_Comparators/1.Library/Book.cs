namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Book
    {
        public Book()
        {
            this.Authors = new List<string>(1);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }
    }
}
