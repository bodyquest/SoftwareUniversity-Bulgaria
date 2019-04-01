using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCombination
{
    class TicketCombination
    {
        static void Main(string[] args)
        {


            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());
            int sum = letter1 + letter2 + letter3;
            Console.WriteLine(sum);



            //int num = int.Parse(Console.ReadLine());
            //int count = 0;

            //for (char stadium = 'B'; stadium <= 'L'; stadium++)
            //{

            //    string combination = stadium.ToString();
            //    int reward = stadium;
            //    count++;
            //    if (num == count)
            //    {
            //        Console.WriteLine($"Ticket combination: {combination}");
            //        Console.WriteLine($"Prize: {reward} lv.");
            //    }
            //}
        }
    }
}

