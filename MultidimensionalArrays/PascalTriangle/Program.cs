using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                for (int cow = 0; cow < row + 1; cow++)
                {
                    if (row - 1 >= 0 && cow < pascal[row - 1].Length)
                        pascal[row][cow] += pascal[row - 1][cow];
                    if (row - 1 >= 0 && cow - 1 >= 0)
                        pascal[row][cow] += pascal[row - 1][cow - 1];
                    if (pascal[row][cow] == 0)
                        pascal[row][cow] = 1;
                }
                Console.WriteLine(string.Join(" ", pascal[row]));
            }
        }
    }
}
