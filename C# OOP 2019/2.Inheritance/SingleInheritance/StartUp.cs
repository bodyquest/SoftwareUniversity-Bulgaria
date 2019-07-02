using System;

namespace Farm
{
    class Program
    {
        static void Main()
        {
            Dog dog = new Dog();
            Console.WriteLine(dog.Eat());
            Console.WriteLine(dog.Bark());
        }
    }
}
