namespace Problem1
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var liquids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var items = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> liquidQueue = new Queue<int>(liquids);
            Stack<int> itemsStack = new Stack<int>(items);
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["Aluminium"] = 0;
            materials["Carbon fiber"] = 0;
            materials["Glass"] = 0;
            materials["Lithium"] = 0;
            

            while (liquidQueue.Count > 0 || itemsStack.Count > 0)
            {
                int liquid = -1;
                int item = -1;
                if (liquidQueue.Count > 0)
                {
                    liquid = liquidQueue.Peek();
                }
                if (itemsStack.Count > 0)
                {
                    item = itemsStack.Peek();
                }

                if (liquid == -1 || item == -1)
                {
                    break;
                }
                
                if (liquid + item == 25)
                {
                    materials["Glass"]++;
                    RemoveLiquidAndItem(liquidQueue, itemsStack);
                    continue;
                }
                else if (liquid + item == 50)
                {
                    materials["Aluminium"]++;
                    RemoveLiquidAndItem(liquidQueue, itemsStack);
                    continue;
                }
                else if (liquid + item == 75)
                {
                    materials["Lithium"]++;
                    RemoveLiquidAndItem(liquidQueue, itemsStack);
                    continue;
                }
                else if (liquid + item == 100)
                {
                    materials["Carbon fiber"]++;
                    RemoveLiquidAndItem(liquidQueue, itemsStack);
                    continue;
                }

                else
                {
                    if (liquidQueue.Count == 0)
                    {
                        break;
                    }
                    if (itemsStack.Count == 0)
                    {
                        break;
                    }
                    liquidQueue.Dequeue();
                    item += 3;
                    itemsStack.Pop();
                    itemsStack.Push(item);
                }
            }

            bool succeeded = true;
            foreach (var item in materials)
            {
                if (item.Value == 0)
                {
                    succeeded = false;
                    break;
                }
            }

            if (!succeeded)
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");

                if (liquidQueue.Count == 0)
                {
                    Console.WriteLine($"Liquids left: none");
                }
                else
                {
                    Console.Write("Liquids left: ");
                    Console.WriteLine(string.Join(", ", liquidQueue));
                }

                if (itemsStack.Count == 0)
                {
                    Console.WriteLine($"Physical items left: none");
                }
                else
                {
                    Console.Write("Physical items left: ");
                    Console.WriteLine(string.Join(", ", itemsStack));
                }

                PrintMaterials(materials);
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
                Console.WriteLine($"Liquids left: none");
                Console.WriteLine($"Physical items left: none");
                PrintMaterials(materials);
            }
        }

        private static void PrintMaterials(Dictionary<string, int> materials)
        {
            foreach (var item in materials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void RemoveLiquidAndItem(Queue<int> liquidQueue, Stack<int> itemsStack)
        {
            liquidQueue.Dequeue();
            itemsStack.Pop();
        }
    }
}
