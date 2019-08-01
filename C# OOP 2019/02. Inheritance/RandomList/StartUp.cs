using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            var randomList = new RandomList<string>();
            randomList.Add("Test");
            randomList.Add("Ivan");
            randomList.Add("Pesho");
            randomList.Add("Maria");

            Console.WriteLine(randomList.RemoveRandom());
        }
    }
}
