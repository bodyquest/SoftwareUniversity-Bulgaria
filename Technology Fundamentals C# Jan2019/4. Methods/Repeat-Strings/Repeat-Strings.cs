using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            RepeatString(str, n);
        }

        private static void RepeatString(string str, int n)
        {
            string strAdd = string.Empty;
            for (int i = 0; i < n; i++)
            {
                Console.Write(str + strAdd);
            }
            Console.WriteLine();
        }
    }
}
