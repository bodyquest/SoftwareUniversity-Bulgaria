using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Trainegram
{
    class Trainegram
    {
        static void Main()
        {
            var list = new List<string>();
            string input = Console.ReadLine();

            Regex regexTrain = new Regex(@"^(<\[[^a-zA-Z0-9]*\]\.)+(\.\[([a-zA-Z0-9])*\]\.)*$");

            while (input != "Traincode!")
            {
                if (regexTrain.IsMatch(input))
                {
                    list.Add($"{input}\n");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("", list));
        }
    }
}
