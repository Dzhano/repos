using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EasterSurprise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int r = s[0];
            int c = s[1];
            char[,] matrix = new char[r,c];
            for (int i = 0; i < r; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < c; j++) 
                    matrix[i, j] = input[j];
            }

            char initialSymbol = char.Parse(Console.ReadLine());

            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int initialR = coordinates[0];
            int initialC = coordinates[1];
            char symbol = matrix[initialR, initialC];

            List<int[]> cords = new List<int[]>();
            cords.Add(coordinates);

            while (cords.Count > 0)
            {
                initialR = cords[0][0];
                initialC = cords[0][1];
                matrix[initialR, initialC] = initialSymbol;
                if (initialR - 1 >= 0)
                {
                    if (matrix[initialR - 1, initialC] == symbol)
                    {
                        matrix[initialR - 1, initialC] = initialSymbol;
                        cords.Add(new int[] { initialR - 1, initialC });
                    }
                }
                if (initialR + 1 < r)
                {
                    if (matrix[initialR + 1, initialC] == symbol)
                    {
                        matrix[initialR + 1, initialC] = initialSymbol;
                        cords.Add(new int[] { initialR + 1, initialC });
                    }
                }
                if (initialC - 1 >= 0)
                {
                    if (matrix[initialR, initialC - 1] == symbol)
                    {
                        matrix[initialR, initialC - 1] = initialSymbol;
                        cords.Add(new int[] { initialR, initialC - 1 });
                    }
                }
                if (initialC + 1 < c)
                {
                    if (matrix[initialR, initialC + 1] == symbol)
                    {
                        matrix[initialR, initialC + 1] = initialSymbol;
                        cords.Add(new int[] { initialR, initialC + 1 });
                    }
                }
                cords.RemoveAt(0);
            }

            for (int i = 0; i < r; i++) 
            {
                for (int j = 0; j < c; j++) 
                    Console.Write(matrix[i, j]);
                Console.WriteLine();
            }
        }
    }
}
