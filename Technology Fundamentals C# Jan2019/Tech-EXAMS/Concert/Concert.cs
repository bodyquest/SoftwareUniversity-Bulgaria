namespace Concert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Program
    {
        static void Main()
        {
            var band = new Dictionary<string, List<string>>();
            var bandPlayTime = new Dictionary<string, int>();
            int bandTotalPlayTime = 0;

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                string[] bandInfo = input.Split("; ");
                string action = bandInfo[0];
                string bandName = bandInfo[1];

                if (action == "Add")
                {
                    string[] membersInfo = bandInfo[2].Split(", ");

                    if (!band.ContainsKey(bandName))
                    {
                        band[bandName] = new List<string>();
                        AddMembers(band, bandName, membersInfo);
                    }
                    else
                    {
                        AddMembers(band, bandName, membersInfo);
                    }
                }
                else if (action == "Play")
                {
                    int time = int.Parse(bandInfo[2]);
                    if (!bandPlayTime.ContainsKey(bandName))
                    {
                        bandPlayTime[bandName] = time;
                        bandTotalPlayTime += time;
                    }
                    else
                    {
                        bandPlayTime[bandName] += time;
                        bandTotalPlayTime += time;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total time: {bandTotalPlayTime}");
            foreach (var kvp in bandPlayTime.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            string secondInput = Console.ReadLine();

            if (band.ContainsKey(secondInput))
            {
                Console.WriteLine($"{secondInput}");
                foreach (var member in band[secondInput])
                {
                    Console.WriteLine($"=> {member}");
                }
            }
        }

        private static void AddMembers(Dictionary<string, List<string>> band, string bandName, string[] membersInfo)
        {
            for (int i = 0; i < membersInfo.Length; i++)
            {
                // check if there are duplicates
                if (!band[bandName].Contains(membersInfo[i]))
                {
                    band[bandName].Add(membersInfo[i]);
                }
            }
        }
    }
}
