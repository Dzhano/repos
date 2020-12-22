using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            int c = (int)a;
            int d = (int)b;
            if (c < d)
            {
                CharactersInRange(c, d);
            }
            else if (d < c)
            {
                CharactersInRange(d, c);
            }
        }

        static void CharactersInRange(int a, int b)
        {
            for (int i = a + 1; i < b; i++)
            {
                char c = (char) i;
                Console.Write($"{c} ");
            }
        }
    }
}
