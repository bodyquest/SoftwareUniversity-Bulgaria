using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Girder
{
    class Program
    {
        static void Main()
        {
            var townRecord = new Dictionary<string, int>();
            var townPassenegrs = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "Slide rule")
            {
                var array = input.Split(":").ToArray();
                string town = array[0];
                string[] restOfData = array[1].Split("->");
                int time = 0;
                int passengers = 0;
                int.TryParse(restOfData[0], out time);
                AddRailwayPassengerAndTimeData(townRecord, townPassenegrs, town, restOfData, time);

                input = Console.ReadLine();
            }

            var passengersList = new Dictionary<string, int>();
            foreach (var town in townPassenegrs)
            {
                if (!passengersList.ContainsKey(town.Key))
                {
                    passengersList[town.Key] = town.Value;
                }
                else
                {
                    passengersList[town.Key] += town.Value;
                }
            }
            foreach (var town in townRecord.OrderBy(x => x.Value).ThenBy(x =>x.Key))
            {
                string townName = town.Key;
                int recordTime = town.Value;
                if (townRecord[townName] > 0 && townPassenegrs[townName] > 0)
                {
                    Console.WriteLine($"{townName} -> Time: {recordTime} -> Passengers: {passengersList[townName]}");
                }
            }
        }

        private static int AddRailwayPassengerAndTimeData(Dictionary<string, int> townRecord, Dictionary<string, int> townPassenegrs, string town, string[] restOfData, int time)
        {
            int passengers;
            if (time > 0)
            {
                passengers = int.Parse(restOfData[1]);
                if (!townRecord.ContainsKey(town))
                {
                    townRecord[town] = time;
                    townPassenegrs[town] = passengers;
                }
                else
                {
                    if (townRecord[town] > time || townRecord[town] == 0)
                    {
                        townRecord[town] = time;
                    }
                    townPassenegrs[town] += passengers;
                }
            }
            else
            {
                passengers = int.Parse(restOfData[1]);

                if (townRecord.ContainsKey(town))
                {
                    //REMOVE the record, and decrease total passengers with current passengers
                    townRecord[town] = 0;
                    townPassenegrs[town] -= passengers;
                }
            }

            return passengers;
        }
    }
}
