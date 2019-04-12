using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind_Palace
{
    class Program
    {
        static void Main()
        {
            var chestsDetails = new Dictionary<string, string>();
            var chests = new Dictionary<string, List<string>>();

            int countTotal = 0;
            int countImportant = 0;

            string input = Console.ReadLine();
            while (input != "END")
            {
                var entry = input.Split(" - ");
                if (entry.Length == 3)
                {
                    GetChests(chestsDetails, entry);
                }
                else if(entry.Length == 4)
                {
                    AddImportantItems(chests, ref countTotal, ref countImportant, entry);
                }

                input = Console.ReadLine();
            }

            //TO PRINT
            Console.WriteLine($"Herlock's Mind Palace:");
            foreach (var chest in chests)
            {
                Console.WriteLine($"{chestsDetails[chest.Key]}");
                foreach (var item in chest.Value)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Herlock's total items: {countTotal}");
            Console.WriteLine($"Herlock's important items: {countImportant}");
        }

        private static void GetChests(Dictionary<string, string> chestsDetails, string[] entry)
        {
            string chest = entry[0];
            string description = entry[1];
            string category = entry[2];
            if (!chestsDetails.ContainsKey(chest))
            {
                chestsDetails[chest] = ($"{chest} - ({category})\n-- {description}");
            }
        }

        private static void AddImportantItems(Dictionary<string, List<string>> chests, ref int countTotal, ref int countImportant, string[] entry)
        {
            if (int.Parse(entry[3]) > 3)
            {
                string dateAsText = entry[2];
                DateTime date = DateTime.ParseExact(dateAsText, "dd/MM/yyyy", null);
                int year = int.Parse(date.ToString("yyyy"));
                string month = date.ToString("MMM");
                string item = entry[0];
                string chest = entry[1];

                if (year > 2005)
                {
                    if (!chests.ContainsKey(chest))
                    {
                        chests[chest] = new List<string>();
                        chests[chest].Add($"---- {item}, acquired {month} {year}.");
                        countImportant++;
                    }
                    else
                    {
                        chests[chest].Add($"---- {item}, acquired {month} {year}.");
                        countImportant++;
                    }
                }
                countTotal++;
            }
            else
            {
                countTotal++;
            }
        }
    }
}
