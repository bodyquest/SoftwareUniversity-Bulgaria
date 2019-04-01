using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Book_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var userSide = new Dictionary<string, string>();
            string[] array = new string[0];
            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {

                var temp = input.ToCharArray();
                if (temp.Contains('|'))
                {
                    array = input.Split(" | ");
                    string side = array[0];
                    string user = array[1];
                    if (!userSide.ContainsKey(user))
                    {
                        userSide[user] = side;
                    }
                }
                else if (temp.Contains('>'))
                {
                    array = input.Split(" -> ");
                    string side = array[1];
                    string user = array[0];
                    if (userSide.ContainsKey(user))
                    {
                        userSide[user] = side;
                    }
                    else
                    {
                        userSide[user] = side;
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
                input = Console.ReadLine();
            }

            var filtered = userSide
                .GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.ToDictionary(d => d.Key, y => y.Value))
                .OrderByDescending(x=>x.Value.Count)
                .ThenBy(x=>x.Key);

            foreach (var item in filtered)
            {
                string side = item.Key;
                Dictionary<string, string> suerSideValue = item.Value;
                Console.WriteLine($"Side: {side}, Members: {suerSideValue.Count}");

                foreach (var user in suerSideValue.OrderBy(x=>x.Key))
                {
                    string name = user.Key;
                    string side2 = user.Value;
                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
