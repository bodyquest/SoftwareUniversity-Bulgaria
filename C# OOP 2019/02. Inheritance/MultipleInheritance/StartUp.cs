namespace Farm
{
    using System;

    public class Program
    {
        static void Main()
        {
            Puppy puppy = new Puppy();
            Console.WriteLine(puppy.Eat());
            Console.WriteLine(puppy.Bark());
            Console.WriteLine(puppy.Weep());
        }
    }
}
