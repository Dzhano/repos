using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = SmallestNum(a, b, c);
            Console.WriteLine(result);
        }

        static int SmallestNum(int a, int b, int c)
        {
            int smallest = Math.Min(a, Math.Min(b, c));
            return smallest;
        }
    }
}
