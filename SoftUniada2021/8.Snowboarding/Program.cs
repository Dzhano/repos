using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Snowboarding
{
    class Program
    {
        static void Main(string[] args)
        {
            int endurance = int.Parse(Console.ReadLine());
            string[] namesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] endurancesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] obstaclesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Dictionary<string, int[]> tracks = new Dictionary<string, int[]>();
            int length = namesInput.Length;
            for (int i = 0; i < length; i++)
            {
                tracks.Add(namesInput[i], new int[] { endurancesInput[i], obstaclesInput[i] });
            }
            tracks = tracks.OrderByDescending(t => t.Value[1])
                .ThenByDescending(t => t.Value[0])
                .ToDictionary(x => x.Key, x => x.Value);

            
        }
    }
}
