using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.HolidayTreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> treats = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Reverse().ToList();
            int totalTreats = treats.Sum();
            int k = int.Parse(Console.ReadLine());

            if (totalTreats % k != 0) Console.WriteLine("Packaging is not possible!");
            else
            {
                int treatsNumber = totalTreats / k;
                List<List<int>> packageTreats = new List<List<int>>();

                while (treats.Count > 0)
                {
                    List<int> checkpoints = new List<int>();

                    List<int> treat = new List<int>();
                    for (int i = 0; i < treats.Count; i++)
                    {
                        if (treat.Sum() + treats[i] <= treatsNumber)
                        {
                            treat.Add(treats[i]);
                            checkpoints.Add(i);
                        }
                    }
                    ;
                    while (treat.Sum() < treatsNumber)
                    {
                        int checkpoint = checkpoints[checkpoints.Count - 1] + 1;
                        treat.RemoveAt(treat.Count - 1);
                        checkpoints.RemoveAt(checkpoints.Count - 1);
                        for (int i = checkpoint; i < treats.Count; i++)
                        {
                            if (treat.Sum() + treats[i] <= treatsNumber)
                            {
                                treat.Add(treats[i]);
                                checkpoints.Add(i);
                            }
                        }
                    }
                    for (int i = checkpoints.Count - 1; i >= 0; i--)
                        treats.RemoveAt(checkpoints[i]);

                    List<int> reversedTreat = new List<int>();
                    for (int i = treat.Count - 1; i >= 0; i--)
                        reversedTreat.Add(treat[i]);
                    packageTreats.Add(reversedTreat);
                }

                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine($"Package {i} is");
                    foreach (int item in packageTreats[i])
                        Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
        }
    }
}
