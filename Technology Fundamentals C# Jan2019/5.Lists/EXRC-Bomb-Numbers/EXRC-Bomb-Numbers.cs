using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bombNum = bomb[0];
            int bombPow = bomb[1];

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] == bombNum)
                {
                    for (int k = 0; k < bombPow; k++)
                    {
                        if (index < list.Count)
                        {
                            list.RemoveAt(index + 1);
                        }
                    }
                    for (int i = 0; i < bombPow; i++)
                    {
                        if (index > 0)
                        {
                            list.RemoveAt(index - 1);
                            index--;
                        }
                    }
                }
            }
            list.RemoveAll(n => n == bombNum);

            int sum = list.Sum();
            if (list.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(sum);
            }
        }
    }
}
