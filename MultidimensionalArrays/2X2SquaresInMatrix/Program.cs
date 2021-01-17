using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Runtime error
            int[] size = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < size[1]; j++)
                    matrix[i, j] = input[j];
            }
            int squares = 0;
            for (int i = 0; i < size[0] - 1; i++)
                for (int j = 0; j < size[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i + 1, j] == matrix[i + 1, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                        squares++;
                }
            Console.WriteLine(squares);
        }
    }
}
