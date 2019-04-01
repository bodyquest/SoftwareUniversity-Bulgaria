using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Group_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            char capLetter = char.Parse(Console.ReadLine());
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int count = 0;

            for (char one = 'A'; one <= capLetter; one++)
            {
                for (char two = 'a'; two <= firstLetter; two++)
                {
                    for (char three = 'a'; three <= secondLetter; three++)
                    {
                        for (char four = 'a'; four <= thirdLetter; four++)
                        {
                            for (int five = 0; five <= num; five++)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count -1);
        }
    }
}
