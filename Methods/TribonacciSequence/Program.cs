using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int number = 1;
            Console.Write($"{number} ");
            int a = 0;
            int b = 0;
            int c = number;
            for (int i = 2; i <= num; i++)
            {
                Console.Write($"{number} ");
                a = b;
                b = c;
                c = number;
                number = a + b + c;
            }
        }
    }
}
