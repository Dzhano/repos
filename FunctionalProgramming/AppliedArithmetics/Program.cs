using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                Func<int[], int[]> function = x =>
                {
                    List<int> numbers = new List<int>();
                    foreach (int num in x)
                        numbers.Add(num);
                    if (command == "print") Console.WriteLine(string.Join(" ", x));
                    else 
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            switch (command)
                            {
                                case "add":
                                    numbers[i]++;
                                    break;
                                case "multiply":
                                    numbers[i] *= 2;
                                    break;
                                case "subtract":
                                    numbers[i]--;
                                    break;
                            }
                        }
                    return numbers.ToArray();
                };
                numbers = function(numbers);
            }
        }
    }
}
