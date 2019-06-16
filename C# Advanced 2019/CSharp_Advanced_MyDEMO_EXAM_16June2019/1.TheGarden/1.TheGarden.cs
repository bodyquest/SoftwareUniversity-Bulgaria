using System;
using System.Linq;

namespace _1.TheGarden
{
    class Program
    {
        static void Main()
        {
            //TO FIX MINOR BUG 87/100

            int rows = int.Parse(Console.ReadLine());
            string[][] jaggedArray = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                var veggies = Console.ReadLine().Split(' ').ToArray();
                jaggedArray[i] = veggies;
            }

            string input = Console.ReadLine();
            int carrotsCount = 0;
            int potatoesCount = 0;
            int lettuceCount = 0;
            int harmedVeggies = 0;

            while (input != "End of Harvest")
            {
                var tokens = input.Split(' ').ToArray();
                string operation = tokens[0].ToLower();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                string direction = string.Empty;

                if (tokens.Length == 4)
                {
                    direction = tokens[3].ToLower();
                }

                if (row >= 0
                    && row < jaggedArray.GetLength(0)
                    && col >= 0
                    && col < jaggedArray[row].Length)
                {
                    if (operation == "harvest")
                    {
                        if (jaggedArray[row][col] != " ")
                        {
                            switch (jaggedArray[row][col])
                            {
                                case "C": carrotsCount++; break;
                                case "P": potatoesCount++; break;
                                case "L": lettuceCount++; break;
                                default:
                                    break;
                            }

                            jaggedArray[row][col] = " ";
                        }
                    }
                    else if (operation == "mole")
                    {
                        if (direction == "up")
                        {
                            for (int moleRow = row; moleRow >= 0; moleRow -= 2)
                            {
                                harmedVeggies = HarmVeggie(jaggedArray, harmedVeggies, moleRow, col);
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int moleRow = row; moleRow < jaggedArray.GetLength(0); moleRow += 2)
                            {
                                harmedVeggies = HarmVeggie(jaggedArray, harmedVeggies, moleRow, col);
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int moleCol = col; moleCol >= 0; moleCol -= 2)
                            {
                                harmedVeggies = HarmVeggieByCol(jaggedArray, harmedVeggies, row, moleCol);
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int moleCol = col; moleCol < jaggedArray[row].Length; moleCol += 2)
                            {
                                harmedVeggies = HarmVeggieByCol(jaggedArray, harmedVeggies, row, moleCol);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine($"Carrots: {carrotsCount}");
            Console.WriteLine($"Potatoes: {potatoesCount}");
            Console.WriteLine($"Lettuce: {lettuceCount}");
            Console.WriteLine($"Harmed vegetables: {harmedVeggies}");
        }

        private static int HarmVeggie(string[][] jaggedArray, int harmedVeggies, int moleRow, int col)
        {
            if (jaggedArray[moleRow][col] != " ")
            {
                harmedVeggies+=1;
                jaggedArray[moleRow][col] = " ";
            }

            return harmedVeggies;
        }

        private static int HarmVeggieByCol(string[][] jaggedArray, int harmedVeggies, int row, int moleCol)
        {
            if (jaggedArray[row][moleCol] != " ")
            {
                harmedVeggies += 1;
                jaggedArray[row][moleCol] = " ";
            }

            return harmedVeggies;
        }
    }
}
