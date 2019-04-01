using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Five
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPassengersStart = int.Parse(Console.ReadLine());
            int numStops = int.Parse(Console.ReadLine());

            for (int passengers = 1; passengers <= numStops; passengers++)
            {
                if (passengers % 2 != 0)
                {
                    int passOut = int.Parse(Console.ReadLine());
                    numPassengersStart -= passOut;
                    int passIn = int.Parse(Console.ReadLine());
                    numPassengersStart += passIn;
                    numPassengersStart += 2;
                }
                else
                {
                    int passOut = int.Parse(Console.ReadLine());
                    numPassengersStart -= passOut;
                    int passIn = int.Parse(Console.ReadLine());
                    numPassengersStart += passIn;
                    numPassengersStart -= 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {numPassengersStart}");

        }
    }
}
