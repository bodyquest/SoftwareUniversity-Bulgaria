using System;
using System.Collections;

namespace Supermarket
{
    class Supermarket
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Queue supermarket = new Queue();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    supermarket.Enqueue(input);
                }
                else
                {
                    while (supermarket.Count > 0)
                    {
                        string customer = supermarket.Dequeue().ToString();
                        Console.WriteLine(customer);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{supermarket.Count} people remaining");
        }
    }
}
