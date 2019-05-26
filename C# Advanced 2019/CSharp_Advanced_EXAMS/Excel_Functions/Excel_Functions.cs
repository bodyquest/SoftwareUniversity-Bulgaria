namespace Excel_Functions
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(", ").ToArray();
            string[][] excel = new string[n][];
            FillExcell(n, input, excel);

            var command = Console.ReadLine().Split(' ').ToArray();

            string header = command[1];
            if (command[0] == "hide")
            {
                RemoveColumn(n, input, excel, header);
            }
            else if (command[0] == "sort")
            {
                string[][] newTable = new string[n][];
                int index = -1;

                for (int i = 0; i < excel[0].Length; i++)
                {
                    if (excel[0][i] == header)
                    {
                        index = i;
                    }
                }

                Sort<string>(excel, index);

            }
            else if (command[0] == "filter")
            {
                string value = command[2];
                
            }

            // TO DO PRINT
            Console.WriteLine("kurami qnko");
        }

        private static void Sort<T>(T[][] excel, int index)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(excel, (x, y) => comparer.Compare(x[index], y[index]));
        }

        private static string[][] FillExcell(int n, string[] input, string[][] excel)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int col = 0; col < input.Length; col++)
                {
                    excel[i] = new string[input.Length];
                    excel[i][col] = input[col];
                }

                input = Console.ReadLine().Split(", ").ToArray();
            }

            return excel;
        }

        private static string[][] RemoveColumn(int n, string[] input, string[][] excel, string header)
        {
            string[][] newTable = new string[n][];
            int index = -1;
            for (int i = 0; i < excel.Length; i++)
            {
                for (int col = 0; col < excel[i].Length - 1; col++)
                {
                    newTable[i] = new string[excel[i].Length - 1];
                    if (excel[i][col] == header)
                    {
                        index = col;
                    }
                    if (col > index)
                    {
                        newTable[i][col-1] = excel[i][col];
                    }
                    else if (col < index)
                    {
                        newTable[i][col] = excel[i][col];
                    }
                }
            }

            return newTable;
        }
    }
}
