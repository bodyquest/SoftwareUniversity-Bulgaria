using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Once upon a time")
            {
                var dwarfInfo = input.Split(" <:> ").ToArray();
                string name = dwarfInfo[0];
                string hatColor = dwarfInfo[1];
                int physics = int.Parse(dwarfInfo[2]);

                if (!dwarfs.ContainsKey(name))
                {
                    dwarfs[name] = new Dictionary<string, int>();
                    dwarfs[name].Add(hatColor, physics);
                }
                else if (dwarfs.ContainsKey(name) && !dwarfs[name].ContainsKey(hatColor))
                {
                    if (dwarfs[name].ContainsKey(hatColor) && dwarfs[name][hatColor] < physics)
                    {
                        dwarfs[name][hatColor] = physics;
                    }
                    dwarfs[name].Add(hatColor, physics);
                }

                input = Console.ReadLine();
            }
            /////////////////////////////////////////////////////////////////////////
            // SORTING NESTED DICT BY VALUE --->>> SORT BY COUNT OF NESTED DICT that are the SAME, THEN ADD RESULT IN SORTED DICT, THEN SORT NEW DICT BY VALUE
            /////////////////////////////////////////////////////////////////////////
            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();
            foreach (var hatColor in dwarfs.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}
