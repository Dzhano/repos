using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dolars = pounds * 1.31M;
            Console.WriteLine($"{dolars:F3}");
        }
    }
}
