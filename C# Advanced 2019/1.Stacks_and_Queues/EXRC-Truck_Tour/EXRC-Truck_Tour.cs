using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> petrolStations = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                petrolStations.Enqueue(array);
            }

            int index = 0;
            while (true)
            {
                int totalFuel = 0;
                foreach (var item in petrolStations)
                {
                    int fuel = item[0];
                    int distance = item[1];

                    totalFuel += fuel - distance;
                    if (totalFuel < 0)
                    {
                        index++;
                        int[] pumpToRemove = petrolStations.Dequeue();
                        petrolStations.Enqueue(pumpToRemove);
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
