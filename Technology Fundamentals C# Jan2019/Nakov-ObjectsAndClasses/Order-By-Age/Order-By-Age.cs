using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_By_Age
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Age { get; set; }
        }
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            List<Person> people = new List<Person>();

            while (!array[0].Equals("End"))
            {
                string name = array[0];
                int ID = int.Parse(array[1]);
                int age = int.Parse(array[2]);
                Person newPerson = new Person();
                newPerson.Name = name;
                newPerson.ID = ID;
                newPerson.Age = age;
                people.Add(newPerson);

                array = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var person in people.OrderBy(x => x.Age).ToList())
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
