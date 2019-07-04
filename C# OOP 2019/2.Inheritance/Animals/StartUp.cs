using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                try
                {
                    var data = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string name = data[0];
                    int age;
                    if (!int.TryParse(data[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = data[2];

                    switch (input)
                    {
                        case "Dog": Dog dog = new Dog(name, age, gender);
                            Console.WriteLine("Dog");
                            Console.WriteLine(dog.GetResult());
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine("Cat");
                            Console.WriteLine(cat.GetResult());
                            break;
                        case "Frog":
                            Frog kermit = new Frog(name, age, gender);
                            Console.WriteLine("Frog");
                            Console.WriteLine(kermit.GetResult());
                            break;
                        case "Kitten":
                            Kitten voti = new Kitten(name, age);
                            Console.WriteLine("Kitten");
                            Console.WriteLine(voti.GetResult());
                            break;
                        case "Tomcat":
                            Tomcat tom = new Tomcat(name, age);
                            Console.WriteLine("Tomcat");
                            Console.WriteLine(tom.GetResult());
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
