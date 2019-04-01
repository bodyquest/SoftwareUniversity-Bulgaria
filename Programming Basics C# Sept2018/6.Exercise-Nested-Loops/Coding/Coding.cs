using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Coding
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string num = n.ToString();
            for (int i = 0; i < num.Length; i++)
            {
                int singles = n % 10;
                n /= 10;
                char c = (char)(singles+33);
                if (singles == 0)
                {
                    Console.WriteLine("ZERO");
                }
                else
                {
                    Console.Write("{0}", new string(c, singles));
                    Console.WriteLine();
                }
            }
        }
    }
}
