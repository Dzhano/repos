using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsInput);
            int[] bottlesInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesInput);
            int wastedWaterLiters = 0;
            while (true)
            {
                if (bottles.Peek() >= cups.Peek())
                    wastedWaterLiters += bottles.Pop() - cups.Dequeue();
                else
                {
                    int cupLeters = cups.Dequeue() - bottles.Pop();
                    while (cupLeters > 0)
                    {
                        cupLeters -= bottles.Pop();
                    }
                    wastedWaterLiters -= cupLeters;
                }
                if (cups.Any() && !bottles.Any())
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    break;
                }
                else if (!cups.Any() && bottles.Any())
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {wastedWaterLiters}");
        }
    }
}
