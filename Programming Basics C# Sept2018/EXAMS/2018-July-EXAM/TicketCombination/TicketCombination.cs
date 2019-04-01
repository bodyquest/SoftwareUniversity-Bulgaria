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
            int num = int.Parse(Console.ReadLine());
            int count = 0;

            for (char stadium = 'B'; stadium <= 'L'; stadium ++)
            {
                for (char sector = 'f'; sector >= 'a'; sector--)
                {
                    for (char entrance = 'A'; entrance <= 'C'; entrance++)
                    {
                        for (int row = 1; row <= 10; row++)
                        {
                            for (int seat = 10; seat >= 1; seat--)
                            {
                                if (stadium % 2 == 0)
                                {
                                    string combination = stadium.ToString() + sector.ToString() + entrance.ToString() + row.ToString() + seat.ToString();
                                    int reward = stadium + sector + entrance + row + seat;
                                    count++;
                                    if (num == count)
                                    {
                                        Console.WriteLine($"Ticket combination: {combination}");
                                        Console.WriteLine($"Prize: {reward} lv.");
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

