using System;

namespace Tri_bitSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bit = 7 << p;
            int bitAtPosition = number ^ bit;
            Console.WriteLine(bitAtPosition);
        }
    }
}
