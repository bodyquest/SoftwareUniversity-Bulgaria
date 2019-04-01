using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Dragon_Army
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, List<int>>> dragonArmy = new Dictionary<string,SortedDictionary<string, List<int>>>();

            for (int i = 0; i < n; i++)
            {
                string dragon = Console.ReadLine();
                var stats = dragon.Split(' ');
                string type = stats[0];
                string name = stats[1];
                int damage = 0;
                int health = 0;
                int armor = 0;

                if (int.TryParse(stats[2], out damage))
                {
                    damage = int.Parse(stats[2]);
                }
                else
                {
                    damage = 45;
                }
                if (int.TryParse(stats[3], out health))
                {
                    health = int.Parse(stats[3]);
                }
                else
                {
                    health = 250;
                }
                if (int.TryParse(stats[4], out armor))
                {
                    armor = int.Parse(stats[4]);
                }
                else
                {
                    armor = 10;
                }

                if (!dragonArmy.ContainsKey(type))
                {
                    dragonArmy[type] = new SortedDictionary<string, List<int>>();
                }
                if(!dragonArmy[type].ContainsKey(name))
                {
                    dragonArmy[type][name] = new List<int>();
                }
                else
                {
                    dragonArmy[type][name].Clear();
                }

                dragonArmy[type][name].Add(damage);
                dragonArmy[type][name].Add(health);
                dragonArmy[type][name].Add(armor);
            }

            //TO PRINT
            foreach (var type in dragonArmy)
            {
                Console.WriteLine($"{type.Key}::({GetDragonTypeAvgStats(type.Value)})");
                Console.WriteLine(string.Join("\n", type.Value
.Select(s => $"-{s.Key} -> damage: {s.Value[0]}, health: {s.Value[1]}, armor: {s.Value[2]}")));
            }
        }

        private static object GetDragonTypeAvgStats(SortedDictionary<string, List<int>> names)
        {
            var damageList = new List<int>();
            var healthList = new List<int>();
            var armorList = new List<int>();

            foreach (var item in names)
            {
                damageList.Add(item.Value[0]);
                healthList.Add(item.Value[1]);
                armorList.Add(item.Value[2]);
            }

            return $"{damageList.Average():f2}/{healthList.Average():f2}/{armorList.Average():f2}";
        }
    }
}
