using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine()
            .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1).Select(int.Parse).ToArray();
        string[] targetSumInput = Console.ReadLine().Split();
        int targetSum = int.Parse(targetSumInput[1]);

        Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins) 
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        List<int> sortedCoins = coins.OrderByDescending(c => c).ToList();
        Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
        int currentSum = 0;
        int coinIndex = 0;
        while (currentSum != targetSum && coinIndex < sortedCoins.Count)
        {
            int coin = sortedCoins[coinIndex];
            int remainingSum = targetSum - currentSum;
            int takenCoinsCount = remainingSum / coin;
            if (takenCoinsCount > 0)
            {
                chosenCoins.Add(coin, takenCoinsCount);
                currentSum += coin * takenCoinsCount;
            }
            coinIndex++;
        }
        if (currentSum < targetSum)
        {
            Console.WriteLine("Error");
            Environment.Exit(0);
        }
        return chosenCoins;
    }
}