using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();
            Func<int[], int> count = x => x.Length;
            Func<int[], int> sum = x => x.Sum();
            Console.WriteLine(count(numbers));
            Console.WriteLine(sum(numbers));
        }
    }
}
