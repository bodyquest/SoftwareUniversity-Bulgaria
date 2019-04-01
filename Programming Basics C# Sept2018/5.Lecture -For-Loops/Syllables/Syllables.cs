using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllables
{
    class Syllables
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int value = 0;
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a': value = 1; sum += value; break;
                    case 'e': value = 2; sum += value; break;
                    case 'i': value = 3; sum += value; break;
                    case 'o': value = 4; sum += value; break;
                    case 'u': value = 5; sum += value; break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
