using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public string Name { get; private set; }
    public int Value { get; private set; }
    public int Weight { get; private set; }

    public Item(string name, int value, int weight)
    {
        Name = name;
        Value = value;
        Weight = weight;
    }
}


public class Program
{
    public static void Main()
    {
       
        List<Item> items = new List<Item>();

        int maxCapacity = int.Parse(Console.ReadLine());

        string line = Console.ReadLine();
        while (line != "end")
        {
            string[] itemInfo = line.Split().ToArray();
            Item item = new Item(itemInfo[0], int.Parse(itemInfo[2]), int.Parse(itemInfo[1]));
            items.Add(item);

            line = Console.ReadLine();
        }

        items = items.OrderBy(i => i.Name).ToList();

        int[,] values = new int[items.Count + 1, maxCapacity + 1];
        bool[,] getted = new bool[items.Count + 1, maxCapacity + 1];

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            int rowIndex = i + 1;

            for (int capacity = 1; capacity <= maxCapacity; capacity++)
            {
                if (item.Weight > capacity)
                {
                    continue;
                }

                int exclude = values[rowIndex - 1, capacity];
                int include = item.Value + values[rowIndex - 1, capacity - item.Weight];

                if (include > exclude)
                {
                    values[rowIndex, capacity] = include;
                    getted[rowIndex, capacity] = true;
                }
                else
                {
                    values[rowIndex, capacity] = exclude;
                }
            }

        }
        
        int itemsRemaining = items.Count;
        int capacityRemaining = maxCapacity;
        List<Item> gettedItems = new List<Item>();

        while (itemsRemaining != 0)
        {
            if (getted[itemsRemaining, capacityRemaining])
            {
                gettedItems.Add(items[itemsRemaining - 1]);
                capacityRemaining -= items[itemsRemaining - 1].Weight;
            }

            itemsRemaining--;
        }

        Console.WriteLine("Total Weight: " + gettedItems.Select(i => i.Weight).Sum());
        Console.WriteLine("Total Value: " + values[items.Count, maxCapacity]);
        gettedItems.Reverse();
        Console.WriteLine(string.Join(Environment.NewLine, gettedItems.Select(i => i.Name)));
    }
}
