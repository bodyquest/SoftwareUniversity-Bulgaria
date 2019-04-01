using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 0;

            for (char stadium = 'B'; stadium <= 'L'; stadium++)
            {
                for (char sector = 'f'; sector >= 'a'; sector--)
                {
                    for (char entrance = 'A'; entrance <= 'C'; entrance++)
                    {
                        for (int row = 1; row <= 10; row++)
                        {
                            for (int seat = 10; seat >= 1; seat--)
                            {
                                if (stadium%2 ==0)
                                {
                                    count++;
                                    if (count == num)
                                    {
                                        Console.WriteLine($"Ticket combination: {stadium}{sector}{entrance}{row}{seat}");
                                        Console.WriteLine($"Prize: {stadium + sector + entrance + row + seat} lv.");
                                        return;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                               
                            }
                        }
                    }
                }
            }
        }
    }
}
