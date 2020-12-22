using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // poke power
            int m = int.Parse(Console.ReadLine()); // distance
            int y = int.Parse(Console.ReadLine()); // exhaustion factor
            int begginingN = n;
            int targets = 0;
            while (n >= m)
            {
                n -= m;
                targets += 1;
                if (begginingN / 2 == n && y != 0)
                {
                    n /= y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
    }
}
