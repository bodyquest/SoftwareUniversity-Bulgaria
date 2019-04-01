using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            StringBuilder message = new StringBuilder();
            string temp = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                temp = ((Char)(letter + key)).ToString();
                message.Append(temp);
            }

            Console.WriteLine(message);
        }
    }
}
