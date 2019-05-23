
namespace Fashion_Boutique
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Stack<int> box = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int rackCount = 1;
            while (box.Count > 0)
            {
                int item = box.Pop();
                if (sum + item < capacity)
                {
                    sum += item;
                    
                }
                else if (sum + item == capacity)
                {
                    if(box.Count != 0)
                    {
                        rackCount++;
                        sum = 0;
                    }
                }
                else
                {
                    rackCount++;
                    sum = 0;
                    sum += item;
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
