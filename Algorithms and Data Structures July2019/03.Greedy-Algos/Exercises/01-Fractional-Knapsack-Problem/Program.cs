using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public class Item
    {
        public double Weight { get; set; }
        public double Price { get; set; }

        public Item(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }
    }

    public static void Main(string[] args)
    {
        List<Item> items = new List<Item>();

        int capacity = int.Parse(Console.ReadLine().Split().ToArray()[1]);
        int itemsCount = int.Parse(Console.ReadLine().Split().ToArray()[1]);

        for (int i = 0; i < itemsCount; i++)
        {
            string[] itemInfo = Console.ReadLine().Split(new char[] { ' ', '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Item item = new Item(double.Parse(itemInfo[0]), double.Parse(itemInfo[1]));
            items.Add(item);
        }

        double currCapacity = 0;
        double totalPrice = 0;
        int itemIndex = 0;
        items = items.OrderByDescending(i => i.Price / i.Weight).ToList();
        while (currCapacity != capacity && itemIndex != items.Count)
        {
            double percent = 100;

            if (currCapacity + items[itemIndex].Weight > capacity)
            {
                double remainingCapacity = capacity - currCapacity;
                percent = remainingCapacity * 100 / items[itemIndex].Weight;
            }

            currCapacity += items[itemIndex].Weight * percent / 100;
            totalPrice += items[itemIndex].Price * percent / 100;

            if (percent != 100)
            {
                Console.WriteLine($"Take {percent:f2}% of item with price {items[itemIndex].Price:f2} and weight {items[itemIndex].Weight:f2}");
            }
            else
            {
                Console.WriteLine($"Take 100% of item with price {items[itemIndex].Price:f2} and weight {items[itemIndex].Weight:f2}");
            }

            itemIndex++;
        }

        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}
