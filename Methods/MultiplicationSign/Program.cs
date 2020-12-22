using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            if (num1 == 0 || num2 == 0 || num3 == 0) Console.WriteLine("zero");
            else if (num1 < 0) Sign(num2, num3);
            else if (num1 > 0) Sign2(num2, num3);
        }

        static void Sign(int b, int c)
        {
            if (b < 0 || c < 0)
            {
                if (b < 0)
                {
                    if (c < 0) Console.WriteLine("negative");
                    else Console.WriteLine("positive");
                }
                else if (c < 0) Console.WriteLine("positive");
            }
            else Console.WriteLine("negative");
        }

        static void Sign2(int b, int c)
        {
            if (b < 0 || c < 0)
            {
                if (b < 0)
                {
                    if (c < 0) Console.WriteLine("positive");
                    else Console.WriteLine("negative");
                }
                else if (c < 0) Console.WriteLine("negative");
            }
            else Console.WriteLine("positive");
        }
    }
}
