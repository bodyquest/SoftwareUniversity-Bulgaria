using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main()
        {
            var children = Console.ReadLine().Split(' ').ToArray();
            int num = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(children);
           
            while (kids.Count != 1)
            {
                for (int i = 0; i < num-1; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
