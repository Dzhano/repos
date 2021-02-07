using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(num => int.Parse(num)).Reverse().ToList();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> divisible = x => x % n == 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (divisible(numbers[i]))
                {
                    i--;
                    numbers.RemoveAt(i + 1);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
