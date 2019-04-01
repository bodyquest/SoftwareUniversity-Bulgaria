using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            int count = -1;
            StringBuilder result = new StringBuilder();
            do
            {
                var input = (Console.ReadLine());
                count++;

                if (input == "Bake!")
                {
                    result.Append($"Preparing cake with {count} ingredients.");
                    break;
                }
                result.AppendLine($"Adding ingredient {input}.");
            }
            while (count <= 20);
            Console.WriteLine(result);
        }
    }
}
