using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trainlands
{
    class Trainlands
    {
        static void Main(string[] args)
        {
            var trains = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            string trainName = "";
            string wagonName = "";
            int power = 0;
            string otherTrainName = "";

            while (input != "It's Training Men!")
            {
                if (input.Contains("="))
                {
                    string[] train = input.Split(" = ");
                    trainName = train[0];
                    otherTrainName = train[1];
                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                    }
                    trains[trainName].Clear();
                    foreach (var wagon in trains[otherTrainName])
                    {
                        trains[trainName].Add(wagon.Key, wagon.Value);
                    }
                }
                else if (input.Contains(":"))
                {
                    string[] train = input.Split(" -> ");
                    trainName = train[0];
                    string[] wagons = train[1].Split(" : ");
                    wagonName = wagons[0];
                    power = int.Parse(wagons[1]);
                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                        trains[trainName].Add(wagonName, power);
                    }
                    else
                    {
                        trains[trainName].Add(wagonName, power);
                    }
                }
                else
                {
                    string[] train = input.Split(" -> ");
                    trainName = train[0];
                    otherTrainName = train[1];
                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                    }
                    foreach (var wagon in trains[otherTrainName])
                    {
                        trains[trainName].Add(wagon.Key, wagon.Value);
                    }
                    trains.Remove(otherTrainName);
                }

                input = Console.ReadLine();
            }

            //TO PRINT
            foreach (var train in trains.OrderByDescending(train => train.Value.Values.Sum()).ThenBy(wagons => wagons.Value.Values.Count()))
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach (var wagon in train.Value.OrderByDescending(wagon => wagon.Value))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
