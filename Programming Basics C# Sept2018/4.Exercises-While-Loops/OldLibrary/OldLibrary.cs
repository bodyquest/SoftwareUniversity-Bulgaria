using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLibrary
{
    class OldLibrary
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int count = 0;

            while (count <= capacity)
            {
                string search = Console.ReadLine();
                //count++;
                if (search == book)
                {
                    //count = count - 1;
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                count++;
                if (count == capacity)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {count} books.");
                    break;
                }
            }
        }
    }
}
