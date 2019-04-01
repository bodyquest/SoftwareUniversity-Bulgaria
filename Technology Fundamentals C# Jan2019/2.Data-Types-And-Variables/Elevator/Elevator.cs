using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = people / capacity;
            if (courses < 1)
            {
                Console.WriteLine(1);
            }
            else if (people % capacity == 0)
            {
                Console.WriteLine($"{courses}");
            }
            else if (people % capacity != 0)
            {
                Console.WriteLine($"{courses + 1}");
            }
            
        }
    }
}
