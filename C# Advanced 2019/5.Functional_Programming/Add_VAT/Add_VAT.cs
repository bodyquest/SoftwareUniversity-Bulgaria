using System;
using System.Collections.Generic;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));

        }
    }
}
