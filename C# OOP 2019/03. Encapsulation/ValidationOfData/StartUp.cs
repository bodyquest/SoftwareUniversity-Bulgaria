namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split(' ');
                try
                {
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));
                    people.Add(person);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            decimal raise = decimal.Parse(Console.ReadLine());

            if (people.Count > 0)
            {
                people.ForEach(p => p.IncreaseSalary(raise));
                people.ForEach(p => Console.WriteLine(p.ToString()));
            }
        }
    }
}
