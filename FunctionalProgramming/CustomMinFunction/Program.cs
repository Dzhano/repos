using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = n =>
            {
                int min = int.MaxValue;
                foreach (int num in n)
                    if (num < min) min = num;
                return min;
            };
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            Console.WriteLine(minNumber(numbers));
        }
    }
}
