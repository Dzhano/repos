using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = Sum(a, b);
            int result = Subtract(d, c);
            Console.WriteLine(result);
        }

        static int Sum(int num, int number)
        {
            int sum = num + number;
            return sum;
        }

        static int Subtract(int num, int number)
        {
            int subtract = num - number;
            return subtract;
        }
    }
}
