using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var train = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(' ').ToArray();
            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    train.Add(int.Parse(input[1]));
                }
                else
                {
                    int passengersToFit = int.Parse(input[0]);
                    for (int i = 0; i < train.Count; i++)
                    {
                        if (train[i]+ passengersToFit <= capacity)
                        {
                            train[i] += passengersToFit;
                            break;
                        }
                    }
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
