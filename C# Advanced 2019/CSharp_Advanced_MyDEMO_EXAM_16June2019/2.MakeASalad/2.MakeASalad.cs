using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var veggies = Console.ReadLine().Split(' ').ToArray();
            var calories = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<string> veggiesQueue = new Queue<string>(veggies);
            Stack<int> saladCalories = new Stack<int>(calories);

            List<int> saladsMade = new List<int>();

            while (saladCalories.Count > 0)
            {
                int salad = saladCalories.Peek();
                while (veggiesQueue.Count > 0 )
                {
                    string veggie = veggiesQueue.Peek();
                    int vegCalories = 0;
                    vegCalories = GetVeggieCalories(veggie);

                    if (salad - vegCalories >=0)
                    {
                        salad -= vegCalories;
                        veggiesQueue.Dequeue();
                        if (veggiesQueue.Count == 0)
                        {
                            saladsMade.Add(saladCalories.Pop());
                            break;
                        }
                    }
                    else
                    {
                        salad -= vegCalories;
                        veggiesQueue.Dequeue();
                        saladsMade.Add(saladCalories.Pop());
                        break;
                    }
                    
                    if (salad == 0)
                    {
                        saladsMade.Add(saladCalories.Pop());
                        break;
                    }
                }

                if (veggiesQueue.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", saladsMade));

            if (veggiesQueue.Count > 0)
            {
                while (veggiesQueue.Count > 0)
                {
                    Console.Write(veggiesQueue.Dequeue());
                    if (veggiesQueue.Count == 0)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }

            if (saladCalories.Count > 0)
            {
                while (saladCalories.Count > 0)
                {
                    Console.Write(saladCalories.Pop());
                    if (saladCalories.Count == 0)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        private static int GetVeggieCalories(string veggie)
        {
            int vegCalories = 0;
            switch (veggie)
            {
                case "tomato": vegCalories = 80; break;
                case "carrot": vegCalories = 136; break;
                case "lettuce": vegCalories = 109; break;
                case "potato": vegCalories = 215; break;
                default:
                    break;
            }

            return vegCalories;
        }
    }
}
