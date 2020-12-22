using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            if (a < b) Sumator(a, b);
            else Sumator(b, a);
        }

        static void Sumator(char a, char b)
        {
            int sum = 0;
            string input = Console.ReadLine();
            foreach (char item in input) if (item > a && item < b) sum += item;
            Console.WriteLine(sum);
        }
    }
}
