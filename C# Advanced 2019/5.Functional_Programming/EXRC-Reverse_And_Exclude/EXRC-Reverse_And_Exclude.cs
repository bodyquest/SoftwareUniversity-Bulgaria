namespace EXRC_Reverse_And_Exclude
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var collection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int[], int[]> filteredResult = x => x.Where(y => y % n != 0).ToArray();
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            collection = collection.Reverse().ToArray();
            print(filteredResult(collection));
        }
    }
}
