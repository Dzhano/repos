using System;

namespace Histogram
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
            double totalNums4 = 0;
            double p4 = 0.0;
            double totalNums5 = 0;
            double p5 = 0.0;
            for (double i = 0; i < n; i++)
            {
                num = double.Parse(Console.ReadLine());
                if (num < 200)
                {
                    totalNums1 += 1;
                }
                else if (num >= 200 && num <= 399)
                {
                    totalNums2 += 1;
                }
                else if (num >= 400 && num <= 599)
                {
                    totalNums3 += 1;
                }
                else if (num >= 600 && num <= 799)
                {
                    totalNums4 += 1;
                }
                else if (num >= 800)
                {
                    totalNums5 += 1;
                }
            }
            p1 = totalNums1 / n * 100;
            p2 = totalNums2 / n * 100;
            p3 = totalNums3 / n * 100;
            p4 = totalNums4 / n * 100;
            p5 = totalNums5 / n * 100;
            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
