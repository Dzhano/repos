using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int digitSum = 0;
            int digit = 0;
            for (int num = 1; num <= n; num++)
            {
                digit = num;
                while (digit > 0)
                {
                    digitSum += digit % 10;
                    digit = digit / 10;
                }
                bool isSpecialNum = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);
                Console.WriteLine("{0} -> {1}", num, isSpecialNum);
                digitSum = 0;
            }
        }
    }
}
