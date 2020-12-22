using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double a2 = Factorial(a);
            double b2 = Factorial(b);
            double result = a2 / b2;
            Console.WriteLine($"{result:F2}");
        }

        static double Factorial(int num)
        {
            double result = 1;
            for (int i = 1; i <= num; i++) result *= i;
            return result;
        }
    }
}
