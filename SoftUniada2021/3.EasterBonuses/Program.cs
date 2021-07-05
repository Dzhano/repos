using System;
using System.Linq;

namespace _3.EasterBonuses
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            int totalBonuses = 0;
            while ((name = Console.ReadLine()) != "stop")
            {
                int[] bonuses = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int bonus = 0;
                for (int i = 0; i < bonuses.Length; i++)
                {
                    int b = 1;
                    for (int j = 0; j < bonuses.Length; j++)
                    {
                        if (i != j)
                            b *= bonuses[j];
                    }
                    bonus += b;
                }
                Console.WriteLine($"{name} has a bonus of {bonus} lv.");
                totalBonuses += bonus;
            }
            Console.WriteLine($"The amount of all bonuses is {totalBonuses} lv.");
        }
    }
}
