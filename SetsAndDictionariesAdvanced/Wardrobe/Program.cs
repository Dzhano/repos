using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe 
                = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(input[0]))
                    wardrobe.Add(input[0], new Dictionary<string, int>());
                string[] clothes = input[1].Split(",");
                foreach (string item in clothes)
                {
                    if (!wardrobe[input[0]].ContainsKey(item))
                        wardrobe[input[0]].Add(item, 0);
                    wardrobe[input[0]][item]++;
                }
            }
            string[] clothing = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var pieceOfClothing in color.Value)
                {
                    Console.Write($"* {pieceOfClothing.Key} - {pieceOfClothing.Value}");
                    if (clothing[0] == color.Key && clothing[1] == pieceOfClothing.Key)
                        Console.WriteLine(" (found!)");
                    else Console.WriteLine();
                }
            }
        }
    }
}
