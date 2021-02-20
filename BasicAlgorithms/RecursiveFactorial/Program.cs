using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }

        static long Factorial(int n)
        {
            if (n == 1) return n;
            return n * Factorial(n - 1);
        }
    }
}
