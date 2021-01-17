using System;
using System.Linq;

namespace SumMatrixElements
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
            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            int sum = 0;
            foreach (int item in matrix)
                sum += item;
            Console.WriteLine(sum);
        }
    }
}
