using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                    matrix[i, j] = input[j];
            }
            char symbol = char.Parse(Console.ReadLine());
            bool exist = false;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        exist = true;
                        Console.WriteLine($"({i}, {j})");
                        break;
                    }
                }
            if (!exist) Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
