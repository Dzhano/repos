using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            a += int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int b = (int) (a / c);
            int e = b * d;
            Console.WriteLine(e);
        }
    }
}
