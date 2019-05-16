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
            var list = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToList();
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
        }
    }
}
