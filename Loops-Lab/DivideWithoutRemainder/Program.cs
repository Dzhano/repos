using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double num = 0;
            double totalNums1 = 0;
            double p1 = 0.0;
            double totalNums2 = 0;
            double p2 = 0.0;
            double totalNums3 = 0;
            double p3 = 0.0;
            for (int i = 0; i < n; i++)
            {
                num = double.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    totalNums1 += 1;
                }
                if (num % 3 == 0)
                {
                    totalNums2 += 1;
                }
                if (num % 4 == 0)
                {
                    totalNums3 += 1;
                }
            }
            p1 = totalNums1 / n * 100;
            p2 = totalNums2 / n * 100;
            p3 = totalNums3 / n * 100;
            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
