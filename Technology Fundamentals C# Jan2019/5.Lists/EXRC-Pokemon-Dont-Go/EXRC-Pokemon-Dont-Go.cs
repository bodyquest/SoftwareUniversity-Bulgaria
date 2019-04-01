using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Pokemon_Dont_Go
{
    class Program
    {
        static void Main()
        {
            // remove received INDEX
            // increase value(with value of removed) of all elements <= removed element
            // decrease value(with value of removed) of all elements > removed element
            //if INDEX < 0, remove first element, last element gets on its place
            // if INDEX > list.Count-1 , remove last element and first element gets on its place
            // increasing/decreasing also applies to the removed 1 and last elements.

            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sum = 0;

            while (list.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    sum += list[0];
                    int temp = list[0];
                    //// LOOP
                    ChangeElements(list, temp);

                    list.RemoveAt(0);
                    list.Insert(0, list[list.Count - 1]);
                }
                else if (index > list.Count - 1)
                {
                    sum += list[list.Count - 1];
                    int temp = list[list.Count - 1];
                    //// LOOP
                    ChangeElements(list, temp);

                    list.RemoveAt(list.Count - 1);
                    list.Add(list[0]);
                }
                else
                {
                    sum += list[index];
                    int temp = list[index];
                    //// LOOP
                    ChangeElements(list, temp);
                    list.RemoveAt(index);
                }
            }

            Console.WriteLine(sum);
        }

        private static void ChangeElements(List<int> list, int temp)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= temp)
                {
                    list[i] += temp;
                }
                else if (list[i] > temp)
                {
                    list[i] -= temp;
                }
            }
        }
    }
}
