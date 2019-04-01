using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var finishIndex = list.Count / 2;
            double leftCar = 0, rightCar = 0;

            for (int i = 0; i < finishIndex; i++)
            {
                if (list[i] == 0)
                {
                    leftCar *= 0.8;
                }
                else
                {
                    leftCar += list[i];
                }
            }
            for (int i = list.Count - 1; i > finishIndex; i--)
            {

                if (list[i] == 0)
                {
                    rightCar *= 0.8;
                }
                else
                {
                    rightCar += list[i];
                }
            }

            if (leftCar < rightCar)
            {
                Console.WriteLine($"The winner is left with total time: {leftCar}");
            }
            else if (leftCar > rightCar)
            {
                Console.WriteLine($"The winner is right with total time: {rightCar}");
            }
        }
    }
}
