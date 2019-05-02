using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            People people = new People();

            for (int i = 0; i < count; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                string name = array[0];
                int age = int.Parse(array[1]);

                Person person = new Person(name, age);
                people.AddPerson(person);
            }

            List<Person> peopleOverThirty = people.GetOlderThanThirty();
            Console.WriteLine(string.Join(Environment.NewLine, peopleOverThirty));
        }
    }
}
