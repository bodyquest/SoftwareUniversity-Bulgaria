using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var res = new Dictionary<int, int>();

        var currentSum = 0;
        var coinIndex = 0;

        coins = coins.OrderByDescending(c => c).ToList();

        while (currentSum != targetSum && coinIndex < coins.Count)
        {
            var currentCoin = coins[coinIndex];

            if (currentSum + currentCoin > targetSum)
            {
                coinIndex++;
                continue;
            }

            var coinsToTake = (targetSum - currentSum) / currentCoin;

            res[currentCoin] = coinsToTake;

            currentSum += coinsToTake * currentCoin;

            coinIndex++;

            if (targetSum == currentSum)
            {
                break;
            }
        }

        if (targetSum != currentSum)
        {
            throw new InvalidOperationException();
        }

        return res;
    }
}