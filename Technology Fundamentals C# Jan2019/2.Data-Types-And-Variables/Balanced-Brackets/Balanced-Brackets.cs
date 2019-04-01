using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string prev = string.Empty;
            bool pair = false;
            int count = 0;
            int balanced = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input== "(")
                {
                    if (prev == "(")
                    {
                        pair = false;
                    }
                    else if (prev == ")")
                    {
                        pair = false;
                    }
                    prev = input;
                    count++;
                }

                else if (input == ")")
                {
                    if (prev == ")")
                    {
                        pair = false;
                    }
                    else if (prev == "(")
                    {
                        pair = true;
                        balanced++;
                    }
                    prev = input;
                    count++;
                }

            }

            if (count == 2* balanced)
            {
                Console.WriteLine("BALANCED");
            }

            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
