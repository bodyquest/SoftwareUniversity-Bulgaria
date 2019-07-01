﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
{
    public class Book : IComparable<Book>
    {
        public int CompareTo(Book other)
        {
            var yearCompare = this.Year - other.Year;
            if (yearCompare == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return yearCompare;
        }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}