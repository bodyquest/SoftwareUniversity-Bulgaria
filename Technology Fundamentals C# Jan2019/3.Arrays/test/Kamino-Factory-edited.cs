using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currSum = 0;
            int bestSum = 0;
            int currIndex = -1;
            int bestIndex = -1;
            int[] bestArray = new int[num];
            int count = 0;
            int subLength = 1;
            int bestSubLength = 1;
            int bestCount = 0;

            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                var array = input.Split(new[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                count++;
                currSum = 0;
                subLength = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 1)
                    {
                        if (array[i + 1] == 1)
                        {
                            currSum++;
                            subLength++;
                        }
                        else
                        {
                            currSum++;
                        }
                    }

                    if (i == array.Length - 1)
                    {
                        currIndex = string.Join("", array).IndexOf("1");
                    }
                }

                if (subLength > bestSubLength)
                {
                    bestSubLength = subLength;
                    bestIndex = currIndex;
                    for (int i = 0; i < array.Length; i++)
                    {
                        bestArray[i] = array[i];
                    }
                    bestCount = count;
                }
                else if (subLength == bestSubLength)
                {
                    if (currIndex < bestIndex)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            bestArray[i] = array[i];
                        }
                        bestSum = currSum;
                        bestCount = count;
                    }
                    else if (currIndex == bestIndex)
                    {
                        if (currSum > bestSum)
                        {
                            bestSum = currSum;
                            bestCount = count;
                            for (int i = 0; i < array.Length; i++)
                            {
                                bestArray[i] = array[i];
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestArray));
        }
    }
}