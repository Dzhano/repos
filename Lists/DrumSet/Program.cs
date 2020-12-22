using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> initialDrumSet = new List<int>();
            foreach (int item in drumSet) initialDrumSet.Add(item);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= int.Parse(command);
                    if (drumSet[i] <= 0)
                    {
                        if (savings >= initialDrumSet[i] * 3)
                        {
                            drumSet[i] = initialDrumSet[i];
                            savings -= initialDrumSet[i] * 3;
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            initialDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
