using System;
using System.Collections;
using System.Linq;

namespace Fast_Food
{
    public class Program
    {
        static void Main()
        {
            int quantity = int.Parse(Console.ReadLine());
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Queue orders = new Queue(list);

            int largestOrder = int.MinValue;
            foreach (var item in orders)
            {
                int i = (int)item;
                if (i > largestOrder)
                {
                    largestOrder = i;
                }
            }
            // TO DO 
            while (orders.Count > 0)
            {
                if (quantity - (int)orders.Peek() > 0)
                {
                    quantity -= (int)orders.Peek();
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine(largestOrder);
                    Console.Write("Orders left: ");
                    var listLeft = orders.ToArray().ToList();
                    Console.WriteLine(string.Join(" ", listLeft));
                    return;
                }
            }

            Console.WriteLine(largestOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
