using System;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int a = num1 / 1000;
            int b = (num1 / 100) % 10;
            int c = (num1 / 10) % 10;
            int d = num1 % 10;
            int e = num2 / 1000;
            int f = (num2 / 100) % 10;
            int r = (num2 / 10) % 10;
            int t = num2 % 10;
            for (int i = a; i <= e; i++)
            {
                for (int k = b; k <= f; k++)
                {
                    for (int u = c; u <= r; u++)
                    {
                        for (int p = d; p <= t; p++)
                        {
                            if (i % 2 != 0 && k % 2 != 0 && u % 2 != 0 && p % 2 != 0)
                            {
                                Console.Write($"{i}{k}{u}{p} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
