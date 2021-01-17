using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                int[] input = Console.ReadLine().Split(", ")
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < size[1]; j++)
                    matrix[i, j] = input[j];
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxRow2 = 0;
            int maxColumn = 0;
            int maxColumn2 = 0;
            for (int i = 0; i < size[0] - 1; i++)
                for (int j = 0; j < size[1] - 1; j++)
                {
                    int max = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (max > maxSum)
                    {
                        maxSum = max;
                        maxRow = matrix[i, j];
                        maxRow2 = matrix[i, j + 1];
                        maxColumn = matrix[i + 1, j];
                        maxColumn2 = matrix[i + 1, j + 1];
                    }
                }
            Console.WriteLine($"{maxRow} {maxRow2}");
            Console.WriteLine($"{maxColumn} {maxColumn2}");
            Console.WriteLine(maxSum);
        }
    }
}
