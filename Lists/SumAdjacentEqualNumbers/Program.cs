using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i - 1 < 0) continue;
                else if (numbers[i] == numbers[i - 1])
                {
                    numbers[i - 1] += numbers[i];
                    numbers.RemoveAt(i);
                    i -= 2;
                    continue;
                }
                if (i + 1 >= numbers.Count) continue;
                else if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i--;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
