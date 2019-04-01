using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_MOBA_Challenger
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> playerPosition = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                if (!input.Contains("vs"))
                {
                    var playerInfo = input.Split(" -> ").ToArray();
                    string name = playerInfo[0];
                    string position = playerInfo[1];
                    int skill = int.Parse(playerInfo[2]);

                    // METHOD- ADD Player
                    AddPlayer(playerPosition, name, position, skill);
                }
                else
                {
                    var playerVsPlayer = input.Split(" vs ").ToArray();
                    string playerOne = playerVsPlayer[0];
                    string playerTwo = playerVsPlayer[1];

                    //METHOD Result from Players Duel
                    GetDuelResult(playerPosition, playerOne, playerTwo);
                }

                input = Console.ReadLine();
            }

            // TO PRINT
            foreach (var item in playerPosition.OrderByDescending(x=>x.Value.Values.ToList().Sum()).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{item.Key}: {playerPosition[item.Key].Values.ToList().Sum()} skill");
                foreach (var playerInfo in item.Value.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"- {playerInfo.Key} <::> {playerInfo.Value}");
                }
            }
        }

        private static void GetDuelResult(Dictionary<string, Dictionary<string, int>> playerPosition, string playerOne, string playerTwo)
        {
            if (playerPosition.ContainsKey(playerOne) && playerPosition.ContainsKey(playerTwo))
            {
                bool haveCommon = false;
                foreach (var itemOne in playerPosition[playerOne])
                {
                    string posOne = itemOne.Key;
                    foreach (var itemTwo in playerPosition[playerTwo])
                    {
                        string posTwo = itemTwo.Key;
                        if (posOne == posTwo)
                        {
                            haveCommon = true;
                            var totalOne = playerPosition[playerOne].Values.ToList().Sum();
                            var totalTwo = playerPosition[playerTwo].Values.ToList().Sum();
                            if (totalOne > totalTwo)
                            {
                                playerPosition.Remove(playerTwo);
                            }
                            else if (totalOne < totalTwo)
                            {
                                playerPosition.Remove(playerOne);
                            }
                            break;
                        }
                    }
                    if (haveCommon)
                    {
                        break;
                    }
                }
            }
        }

        private static void AddPlayer(Dictionary<string, Dictionary<string, int>> playerPosition, string name, string position, int skill)
        {
            if (!playerPosition.ContainsKey(name))
            {
                playerPosition[name] = new Dictionary<string, int>();
                playerPosition[name].Add(position, skill);
            }
            else
            {
                //int query = playerPosition[name][position];
                if (!playerPosition[name].ContainsKey(position))
                {
                    playerPosition[name].Add(position, skill);

                }
                else if (playerPosition[name].ContainsKey(position) && playerPosition[name][position] < skill)
                {
                    playerPosition[name][position] = skill;
                }
            }
        }
    }
}
