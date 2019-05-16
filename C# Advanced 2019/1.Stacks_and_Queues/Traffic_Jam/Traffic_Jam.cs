using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int count = 0;
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
