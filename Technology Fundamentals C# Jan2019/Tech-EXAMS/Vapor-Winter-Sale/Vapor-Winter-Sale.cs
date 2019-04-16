namespace Vapor_Winter_Sale
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Program
    {
        static Dictionary<string, double> discountedGames = new Dictionary<string, double>();
        static Dictionary<string, Dictionary<string, double>> discountedDlcGames = new Dictionary<string, Dictionary<string, double>>();

        static void Main(string[] args)
        {
            var dlcGames = new Dictionary<string, Dictionary<string, double>>();
            var games = new Dictionary<string, double>();

            var data = Console.ReadLine().Split(", ").ToArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains(":"))
                {
                    string[] gameDlc = data[i].Split(":");
                    string game = gameDlc[0];
                    string DLC = gameDlc[1];
                    if (games.ContainsKey(game))
                    {
                        dlcGames[game] = new Dictionary<string, double>();
                        dlcGames[game][DLC] = games[game] * 1.2;
                    }
                }
                else
                {
                    string[] gamePrice = data[i].Split("-");
                    string game = gamePrice[0];
                    double price = double.Parse(gamePrice[1]);
                    if (!games.ContainsKey(game))
                    {
                        games[game] = price;
                    }
                }
            }

            // Decrease price of all Games
            DiscountTheGames(dlcGames, games);

            // TO PRINT
            foreach (var game in discountedDlcGames.OrderBy(game => game.Value.Values.Sum()))
            {
                Console.Write($"{game.Key} - ");
                foreach (var kvp in game.Value)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value:f2}");
                }
            }

            foreach (var game in discountedGames.OrderByDescending(g => g.Value))
            {
                Console.WriteLine($"{game.Key} - {game.Value:f2}");
            }

        }

        private static void DiscountTheGames(Dictionary<string, Dictionary<string, double>> dlcGames, Dictionary<string, double> games)
        {
            discountedGames = new Dictionary<string, double>();
            foreach (var item in games)
            {
                if (!dlcGames.ContainsKey(item.Key))
                {
                    discountedGames[item.Key] = item.Value * 0.8;
                }
            }

            discountedDlcGames = new Dictionary<string, Dictionary<string, double>>();
            foreach (var item in dlcGames)
            {
                discountedDlcGames[item.Key] = new Dictionary<string, double>();
                foreach (var gameInfo in item.Value)
                {
                    discountedDlcGames[item.Key][gameInfo.Key] = gameInfo.Value * 0.5;
                }
            }
        }
    }
}
