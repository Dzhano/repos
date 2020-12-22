using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse).OrderByDescending(m => m).ToArray();
            if (numbers.Length >= 3) Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]}");
            else Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
