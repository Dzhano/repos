using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length; j++)
                    matrix[i, j] = input[j];
            }
            int primary = 0;
            int secondary = 0;
            for (int d = 0; d < n; d++)
            {
                primary += matrix[d, d];
                secondary += matrix[n - 1 - d, d];
            }
            Console.WriteLine(Math.Abs(primary - secondary));
        }
    }
}
