using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int digitSum = 0;
                int digit = i;
                while (digit > 0)
                {
                    digitSum += digit % 10;
                    digit = digit / 10;
                }
                bool special = digitSum == 5 || digitSum == 7 || digitSum == 11;
                Console.WriteLine($"{i} -> {special}");
            }
        }
    }
}
