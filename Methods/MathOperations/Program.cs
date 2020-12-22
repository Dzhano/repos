using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            double calculation = Calculate(num, operation, number);
            Console.WriteLine(Math.Round(calculation));
        }

        static double Calculate(int a, char op, int b)
        {
            double result = 0;
            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
            }
            return result;
        }
    }
}
