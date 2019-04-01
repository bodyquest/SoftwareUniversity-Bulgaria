using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameWars
{
    class NameWars
    {
        static void Main(string[] args)
        {
            string value = String.Empty;
            string winner = String.Empty;
            int max = 0;
            
            do
            {
                value = Console.ReadLine();
                if (value == "STOP")
                {
                    break;
                }
                // Convert the string into a byte[].
                int total = 0;
                byte[] asciiBytes = Encoding.ASCII.GetBytes(value);

                foreach (var i in asciiBytes)
                {
                    total += i;
                }
                if (total > max)
                {
                    max = total;
                    winner = value;
                }

            } while (value != "STOP");
            Console.WriteLine($"Winner is {winner} - {max}!");
        }
    }
}
