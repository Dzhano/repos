using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Print(1, i);
            }
            for (int j = n - 1; j >= 1; j--)
            {
                Print(1, j);
            }
        }

        static void Print(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
