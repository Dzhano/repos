using System;

namespace BitAtPosition1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bitAtPosition1 = (number >> 1) & 1;
            Console.WriteLine(bitAtPosition1);
        }
    }
}
