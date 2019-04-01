using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triples_Of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char first = (char)('a' + i);
                for (int k = 0; k < n; k++)
                {
                    char second = (char)('a' + k);
                    for (int j = 0; j < n; j++)
                    {
                        char third = (char)('a' + j);

                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }

        }
    }
}
