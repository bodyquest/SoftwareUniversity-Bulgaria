using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(", ");

                people.Add(new KeyValuePair<string, int>(person[0], int.Parse(person[1])));

            }

            string filter = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            string[] printPattern = Console.ReadLine().Split(" ");

            people
                .Where(p => filter == "younger" ? p.Value < age : p.Value >= age)
                .ToList()
                .ForEach(p => Printer(p, printPattern));

        }

        static void Printer(KeyValuePair<string, int> person, string[] printPattern)
        {
            if (printPattern.Length == 2)
            {
                Console.WriteLine(printPattern[0] == "name" ?
                $"{person.Key} - {person.Value}" :
                $"{person.Value} - {person.Key}");

            }
            else
            {
                Console.WriteLine(printPattern[0] == "name" ?
                $"{person.Key}" :
                $"{person.Value}");
            }
        }
    }
}
