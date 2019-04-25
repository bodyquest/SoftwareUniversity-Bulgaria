using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Predicate_Party_
{
    class Program
    {
        static void Main()
        {
            var guests = Console.ReadLine().Split(' ').ToList();
            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] commands = input.Split(" ");
                string command = commands[0];
                string filter = commands[1];
                string criteria = commands[2];

                Func<string, string, bool> predicate;
                predicate = GetFunc(filter);

                if (command == "Remove")
                {
                    guests = guests.Where(x => !predicate(x, criteria)).ToList();
                }
                else if (command == "Double")
                {
                    List<string> guestsToAdd = new List<string>();
                    guestsToAdd = guests.Where(x => predicate(x, criteria)).ToList();

                    foreach (var name in guestsToAdd)
                    {
                        int index = guests.IndexOf(name);
                        guests.Insert(index + 1, name);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }

        static Func<string, string, bool> GetFunc(string filter)
        {
            if (filter == "StartsWith")
            {
                return (x, c) => x.StartsWith(c);
            }
            else if (filter == "EndsWith")
            {
                return (x, c) => x.EndsWith(c);
            }
            else if (filter == "Length")
            {
                return (x, c) => x.Length == int.Parse(c);
            }

            return null;
        }
    }
}
