using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                count++;
                Console.Write("{0}", new string('.', n + i)); 
                if (count > n/2)
                {
                    Console.Write("#{0}#", new string ('.', 3*n - 2*i-2));
                    Console.Write("{0}", new string('.', n + i));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("{0}", new string('#', 3 * n - 2 * i));
                    Console.Write("{0}", new string('.', n + i));
                    Console.WriteLine();
                    
                }

                    
            }
        }
    }
}
