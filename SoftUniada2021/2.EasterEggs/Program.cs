using System;

namespace _2.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nums = n;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < j; i++) Console.Write(" ");

                for (int k = 1; k <= nums; k++)
                    Console.Write(k);
                nums -= 1;
                for (int i = nums; i >= 1; i--)
                    Console.Write(i);

                for (int i = 0; i < j; i++) Console.Write(" ");
                Console.WriteLine();
            }
        }
    }
}
