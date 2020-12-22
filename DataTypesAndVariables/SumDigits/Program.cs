using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit = int.Parse(Console.ReadLine());
            int digitSum = 0;
            while (digit > 0)
            {
                digitSum += digit % 10;
                digit = digit / 10;
            }
            Console.WriteLine(digitSum);
        }
    }
}
