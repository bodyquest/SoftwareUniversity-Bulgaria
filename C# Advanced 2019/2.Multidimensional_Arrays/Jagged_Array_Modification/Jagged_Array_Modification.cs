
namespace Jagged_Array_Modification
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int [rows][];

            for (int i = 0; i < rows; i++)
            {
                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jaggedArray[i] = nums;
            }

            string input = Console.ReadLine();


            while (input != "END")
            {
                var tokens = input.Split(' ').ToArray();
                string operation = tokens[0].ToLower();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 
                    || row >= rows 
                    || col < 0 
                    || col >= jaggedArray[row].Length )
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (operation)
                    {
                        case "add":
                            jaggedArray[row][col] += value;
                            break;
                        case "subtract":
                            jaggedArray[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
