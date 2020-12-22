using System;

namespace P_thBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bitAtPosition = (number >> p) & 1;
            Console.WriteLine(bitAtPosition);
        }
    }
}
