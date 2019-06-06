namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Person testPerson = new Person();
            
            Person testPersonTwo = new Person(18);
            Person testPersonThree = new Person("Ivan", 20);

            Console.WriteLine($"{testPerson.Name}\n{testPersonTwo.Age}\n{testPersonThree.Name}");
        }
    }
}
