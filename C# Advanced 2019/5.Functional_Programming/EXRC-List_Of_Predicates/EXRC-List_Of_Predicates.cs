namespace EXRC_List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int upper = int.Parse(Console.ReadLine());
            var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

            // to fill collection without for loop
            var numbers = Enumerable.Range(1, upper).ToList();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var item in inputNumbers)
            {
                predicates.Add(x => x % item == 0);
            }

            for (int i = 0; i < upper; i++)
            {
                bool div = true;
                foreach (var currentPredicates in predicates)
                {
                    if (!currentPredicates(numbers[i]))
                    {
                        div = false;
                        break;
                    }
                }
                if (div)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
