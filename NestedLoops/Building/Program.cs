using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());
            for (int l = level; l >= 1; l--)
            {
                for (int r = 0; r < room; r++)
                {
                    if (l == level)
                    {
                        Console.Write($"L{l}{r} ");
                        if (r == room - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                    else if (l % 2 != 0)
                    {
                        Console.Write($"A{l}{r} ");
                        if (r == room - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.Write($"O{l}{r} ");
                        if (r == room - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
