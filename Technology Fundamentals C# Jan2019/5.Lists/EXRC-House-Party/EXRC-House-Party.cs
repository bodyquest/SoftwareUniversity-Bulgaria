using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partyList = new List<string>();
            int commandsCount = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < commandsCount; i++)
            {
                var guest = Console.ReadLine().Split(' ').ToArray();
                if (guest[2] != "not" && !partyList.Contains(guest[0]))
                {
                    partyList.Add(guest[0]);
                }
                else if (guest[2] != "not" && partyList.Contains(guest[0]))
                {
                    Console.WriteLine($"{guest[0]} is already in the list!");
                }
                else if (guest[2] == "not" && partyList.Contains(guest[0]))
                {
                    partyList.Remove(guest[0]);
                    
                }
                else if (guest[2] == "not" && !partyList.Contains(guest[0]))
                {
                    Console.WriteLine($"{guest[0]} is not in the list!");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, partyList));
        }
    }
}
