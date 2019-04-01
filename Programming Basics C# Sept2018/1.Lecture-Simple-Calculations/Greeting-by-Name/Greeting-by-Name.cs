using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_by_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write your name: ");
            var name = Console.ReadLine();
            Console.Write("Write your age: ");
            var age = Console.ReadLine();
            Console.WriteLine("Hello, {0}, your age is {1}!", name, age);
        }
    }
}
