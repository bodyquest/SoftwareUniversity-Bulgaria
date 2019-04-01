using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chars_To_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append(one);
            sb.Append(two);
            sb.Append(three);
            Console.WriteLine(sb);
        }
    }
}
