using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int memberCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < memberCount; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                string name = array[0];
                int age = int.Parse(array[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine(string.Join(Environment.NewLine, oldest));
        }
    }
}
