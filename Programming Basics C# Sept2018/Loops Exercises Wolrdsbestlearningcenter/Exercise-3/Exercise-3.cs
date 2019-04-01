using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the command keyword to exit a loop in C#?");
            Console.WriteLine("a. int");
            Console.WriteLine("b. continue");
            Console.WriteLine("c. break");
            Console.WriteLine("d. exit");
            Console.Write("Enter your choice: ");

            string answer = Console.ReadLine();
            while (answer != "c")
            {
                Console.WriteLine("Incorrect!");
                Console.Write("Again? Press \"y\" to continue: ");
                string reply = Console.ReadLine();
                if (reply == "y")
                {
                    Console.Write("Enter your choice: ");
                    answer = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            if (answer =="c")
            {
                Console.WriteLine("Correct!");
            }
        }
    }
}
