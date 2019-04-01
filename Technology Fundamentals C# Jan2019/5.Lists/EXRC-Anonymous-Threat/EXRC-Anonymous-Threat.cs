using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();

            var command = Console.ReadLine().Split(' ').ToArray();
            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    ///////////// method to merge /////////////
                    MergeElements(input, startIndex, endIndex);
                }   //////////////////////////////////////////
                else if (command[0] == "divide")
                {
                    int startIndex = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    var toPartition = input[startIndex];
                    ///////////// method to divide /////////////
                    DivideElements(input, startIndex, partitions, toPartition);
                }   //////////////////////////////////////////

                command = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static int DivideElements(List<string> input, int startIndex, int partitions, string toPartition)
        {
            ///////// IF DIVISIBLE ///////////////////
            if (toPartition.Length % partitions == 0)
            {
                int chunkSize = toPartition.Length / partitions;
                List<string> toAdd = new List<string>();
                for (int i = 0; i < toPartition.Length; i += chunkSize)
                {
                    string chunk = toPartition.Substring(i, chunkSize);
                    toAdd.Add(chunk);
                }
                input.RemoveAt(startIndex);
                input.InsertRange(startIndex, toAdd);
                toAdd.Clear();
            }
            /////// IF NOT DIVISIBLE /////////////////
            else
            {
                int chunkSize = (toPartition.Length - (toPartition.Length % partitions)) / partitions;
                List<string> toAdd = new List<string>();
                ///// IF CHUNKS ARE TOO MUCH /////////
                if (partitions >= toPartition.Length)
                {
                    /// decide size of chunks///
                    chunkSize = GetLargestDivisor(toPartition.Length);
                    ///////////////////////////
                    partitions = toPartition.Length / chunkSize;
                    for (int i = 0; i < toPartition.Length; i += chunkSize)
                    {
                        string chunk = toPartition.Substring(i, chunkSize);
                        toAdd.Add(chunk);
                    }

                    input.RemoveAt(startIndex);
                    input.InsertRange(startIndex, toAdd); // insert "toAdd" list, where it should
                    toAdd.Clear();
                }////// IF CHUNKS ARE BELLOW list.Count ////////
                else
                {
                    int lastChunk = chunkSize + toPartition.Length % partitions;
                    for (int i = 0; i < toPartition.Length - lastChunk; i += chunkSize)
                    {
                        string chunk = toPartition.Substring(i, chunkSize);
                        toAdd.Add(chunk);
                    }
                    toAdd.Insert(toAdd.Count, toPartition.Substring(toPartition.Length - lastChunk, lastChunk));
                    input.RemoveAt(startIndex);
                    input.InsertRange(startIndex, toAdd);
                    toAdd.Clear();
                }
            }

            return partitions;
        }

        public static int GetLargestDivisor(int n)
        {
            for (int i = n / 2; i >= 2; i--)
            {
                if (n % i == 0)
                {
                    return i;
                }
            }
            return 1;
        }

        private static void MergeElements(List<string> input, int startIndex, int endIndex)
        {
            if (startIndex <= 0)
            {
                int count = 0;
                if (endIndex >= input.Count)
                {
                    for (int i = 0; i < input.Count - 1; i++)
                    {
                        input[0] += input[i + 1];
                        count++;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        input.RemoveAt(1);
                    }
                }
                else if (endIndex < input.Count)
                {
                    for (int i = 0; i < endIndex; i++)
                    {
                        input[0] += input[i + 1];
                        count++;

                    }
                    for (int j = 0; j < count; j++)
                    {
                        input.RemoveAt(1);
                    }

                }
            }
            else if (startIndex > 0 && startIndex < input.Count - 1)
            {
                int count = 0;
                if (endIndex >= input.Count)
                {
                    for (int i = startIndex; i < input.Count-1; i++)
                    {
                        input[startIndex] += input[i + 1];
                        count++;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        input.RemoveAt(startIndex + 1);
                    }
                    count = 0;
                }
                else if (endIndex > 0 && endIndex < input.Count)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        input[startIndex] += input[i + 1];
                        count++;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        input.RemoveAt(startIndex + 1);
                    }
                    count = 0;
                }
            }
        }
    }
}
