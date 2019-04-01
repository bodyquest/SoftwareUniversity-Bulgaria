using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                char c = char.Parse(Console.ReadLine());
                string symbol = c.ToString();
                sb.Append(symbol);
            }

            StringBuilder reversed = new StringBuilder();
            sb.ToString();
            for (int i = 3 - 1; i >= 0; i--)
            {
                reversed.Append(sb[i]);
                if (i>0)
                {
                    reversed.Append(" ");
                }
            }
            reversed.ToString();
            Console.WriteLine(reversed);
        }
    }
}
