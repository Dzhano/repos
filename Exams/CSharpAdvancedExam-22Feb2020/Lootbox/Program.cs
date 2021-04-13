using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBoxInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondLootBoxInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> firstLootBox = new Queue<int>(firstLootBoxInput);
            Stack<int> secondLootBox = new Stack<int>(secondLootBoxInput);
            List<int> claimedItems = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Pop();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    firstLootBox.Dequeue();
                    claimedItems.Add(firstItem + secondItem);
                }
                else firstLootBox.Enqueue(secondItem);
            }


            if (firstLootBox.Count == 0) Console.WriteLine("First lootbox is empty");
            if (secondLootBox.Count == 0) Console.WriteLine("Second lootbox is empty");

            int sum = claimedItems.Sum();
            if (sum < 100) Console.WriteLine($"Your loot was poor... Value: {sum}");
            else Console.WriteLine($"Your loot was epic! Value: {sum}");
        }
    }
}
