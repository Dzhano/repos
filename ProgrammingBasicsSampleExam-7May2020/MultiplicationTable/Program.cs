using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string cba = Console.ReadLine();
            int c = Math.Abs((char)cba[0]) - 48;
            int b = Math.Abs((char)cba[1]) - 48;
            int a = Math.Abs((char)cba[2]) - 48;
            if (a > 0 && b > 0 && c > 0)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {
                        for (int h = 1; h <= c; h++)
                        {
                            int sum = i * j * h;
                            Console.WriteLine($"{i} * {j} * {h} = {sum};");
                        }
                    }
                }
            }
        }
    }
}
