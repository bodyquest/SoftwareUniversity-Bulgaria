﻿namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Library
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
    }
}
