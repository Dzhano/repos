using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            do
            {
                int product = n * multiplier;
                Console.WriteLine($"{n} X {multiplier} = {product}");
                multiplier += 1;
            } while (multiplier <= 10);
        }
    }
}
