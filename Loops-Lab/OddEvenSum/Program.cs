using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 0;
            int number = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    num += int.Parse(Console.ReadLine());
                }
                else
                {
                    number += int.Parse(Console.ReadLine());
                }
            }
            if (num == number)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {num}");
            }
            else
            {
                int diff = Math.Abs(number - num);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
