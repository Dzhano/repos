using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] bombs = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                    bombs[i, j] = input[j];
            }
            string[] coordinates = Console.ReadLine().Split();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] places = coordinates[i].Split(",")
                    .Select(int.Parse).ToArray();
                int row = places[0];
                int col = places[1];
                if (bombs[row, col] <= 0) continue;
                int value = bombs[row, col];
                for (int k = row - 1; k < row + 2; k++)
                {
                    for (int l = col - 1; l < col + 2; l++)
                    {
                        if (k >= 0 && k < n && l >= 0 && l < n) 
                            if (bombs[k, l] > 0) bombs[k, l] -= value;
                    }
                }
            }
            int aliveCell = 0;
            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (bombs[r,c] > 0)
                    {
                        aliveCell++;
                        sum += bombs[r, c];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCell}");
            Console.WriteLine($"Sum: {sum}");
            for (int p = 0; p < n; p++)
            {
                for (int k = 0; k < n; k++)
                    Console.Write(bombs[p,k] + " ");
                Console.WriteLine();
            }
        }
    }
}
