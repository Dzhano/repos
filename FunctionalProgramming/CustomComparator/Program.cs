using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(num => int.Parse(num)).ToArray();
            Array.Sort(numbers, (a, b) => 
            {
                // a = odd, b = even
                if (a % 2 != 0 && b % 2 == 0) return 1;
                // a = even, b = odd
                else if (a % 2 == 0 && b % 2 != 0) return -1;
                return a.CompareTo(b);
            });
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
