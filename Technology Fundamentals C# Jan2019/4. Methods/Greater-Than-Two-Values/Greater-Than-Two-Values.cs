using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greater_Than_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string one = Console.ReadLine();
            string two = Console.ReadLine();
            Getmax(one, two);
        }

        private static void Getmax(string one, string two)
        {
            if (char.TryParse(one, out char charOne) && char.TryParse(two, out char charTwo))
            {
                if (charOne > charTwo)
                {
                    Console.WriteLine(charOne);
                }
                else if (charOne < charTwo)
                {
                    Console.WriteLine(charTwo);
                }
            }
            else if (int.TryParse(one, out int intOne) && int.TryParse(two, out int intTwo))
            {
                if (intOne > intTwo)
                {
                    Console.WriteLine(intOne);
                }
                else if (intOne < intTwo)
                {
                    Console.WriteLine(intTwo);
                }
            }
            else
            {
                int larger = string.Compare(one, two);
                if (larger == -1)
                {
                    Console.WriteLine(two);
                }
                else if (larger != 0 && larger != 1)
                {
                    Console.WriteLine(one);
                }
            }
        }
    }
}
