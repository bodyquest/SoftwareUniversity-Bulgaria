using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {
        static void Main()
        {
            //CHECK in Judge if errors, USE SortedSet<>

            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string input = Console.ReadLine();

            while (input?.ToLower() != "party")
            {

                if (Char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }

                input = Console.ReadLine();
            } 

            string comingGuests = Console.ReadLine();
            while (comingGuests?.ToLower() != "end")
            {
                if (guests.Contains(comingGuests))
                {
                    guests.Remove(comingGuests);
                }
                else if (vipGuests.Contains(comingGuests))
                {
                    vipGuests.Remove(comingGuests);
                }

                comingGuests = Console.ReadLine();
            }

            Console.WriteLine($"{guests.Count + vipGuests.Count}");
            foreach (var vip in vipGuests)
            {
                Console.WriteLine(vip);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
