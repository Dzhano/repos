using System;
using System.Text;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = Horizontal(n);
            Vertical(text, n);
        }

        static StringBuilder Horizontal(int n)
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                matrix.Append($"{n} ");
            }
            return matrix;
        }

        static void Vertical(StringBuilder text, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(text);
            }
        }
    }
}
