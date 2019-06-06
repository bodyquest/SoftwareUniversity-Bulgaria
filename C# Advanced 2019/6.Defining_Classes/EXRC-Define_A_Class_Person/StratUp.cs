namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Person firstP = new Person();
            firstP.Name = "Pesho";
            firstP.Age = 20;

            Person secondP = new Person("Gosho", 18);
            Person thirdP = new Person("Stamat", 43);
        }
    }
}
