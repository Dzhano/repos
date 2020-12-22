using System;

namespace BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bit = ~(1 << p);
            int bitAtPosition = number & bit;
            Console.WriteLine(bitAtPosition);
        }
    }
}
