using System;
using System.Linq;

namespace OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Не съм сигурен дали трябва да е така. Но всичко си работи поне с дадените примери.
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int result = 0;
            int counter = 0;
            foreach (int num in numbers)
            {
                result = num ^ result;
            }
            Console.WriteLine(result);
        }
    }
}
