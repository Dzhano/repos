using System;

namespace _1.EasterPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int primeNumbers = 0;
            for (int i = n; i <= m; i++)
            {
                int num = i / 2;
                bool not = false;
                for (int j = 2; j <= num; j++)
                    if (i % j == 0) not = true;
                if (not || i == 1) continue;
                Console.Write(i + " ");
                primeNumbers++;
            }
            Console.WriteLine();
            Console.WriteLine($"The total number of prime numbers between {n} to {m} is {primeNumbers}");
        }
    }
}
