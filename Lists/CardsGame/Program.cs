using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (firstPlayerHand.Count > 0 && secondPlayerHand.Count > 0)
            {
                if (firstPlayerHand[0] > secondPlayerHand[0])
                {
                    firstPlayerHand.Add(firstPlayerHand[0]);
                    firstPlayerHand.Add(secondPlayerHand[0]);
                }
                else if (firstPlayerHand[0] < secondPlayerHand[0])
                {
                    secondPlayerHand.Add(secondPlayerHand[0]);
                    secondPlayerHand.Add(firstPlayerHand[0]);
                }
                firstPlayerHand.RemoveAt(0);
                secondPlayerHand.RemoveAt(0);
            }
            if (secondPlayerHand.Count == 0) Console.WriteLine($"First player wins! Sum: {firstPlayerHand.Sum()}");
            else if (firstPlayerHand.Count == 0) Console.WriteLine($"Second player wins! Sum: {secondPlayerHand.Sum()}");
        }
    }
}
