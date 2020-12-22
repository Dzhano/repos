using System;

namespace BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int count = 0;
            string binary = string.Empty;
            while (number > 0)
            {
                int digit = number % 2;
                if (digit == b) count++;
                binary = digit + binary;
                number /= 2;
            }
            Console.WriteLine(count);
        }
    }
}
