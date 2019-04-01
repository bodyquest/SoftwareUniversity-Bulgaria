using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<int>>();
            string[] array = null;
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                array = input.Split(new char[] {' ', '|', '-', '>'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var temp = input.ToCharArray();
                if (temp.Contains('|'))
                {
                    
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
