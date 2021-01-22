using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            int row = 0;
            int col = 0;
            int coals = 0;
            char[,] field = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().Split()
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    field[i, j] = input[j];
                    if (input[j] == 's')
                    {
                        row = i;
                        col = j;
                    }
                    if (input[j] == 'c') coals++;
                }
            }
            bool end = false;
            foreach (string command in commands)
            {
                if (command == "left")
                {
                    if (col - 1 >= 0)
                    {
                        field[row, col] = '*';
                        col -= 1;
                        if (field[row, col] == 'c') coals--;
                        if (field[row, col] == 'e') end = true;
                        field[row, col] = 's';
                    }
                }
                else if (command == "right")
                {
                    if (col + 1 < n)
                    {
                        field[row, col] = '*';
                        col += 1;
                        if (field[row, col] == 'c') coals--;
                        if (field[row, col] == 'e') end = true;
                        field[row, col] = 's';
                    }
                }
                else if (command == "down")
                {
                    if (row + 1 < n)
                    {
                        field[row, col] = '*';
                        row += 1;
                        if (field[row, col] == 'c') coals--;
                        if (field[row, col] == 'e') end = true;
                        field[row, col] = 's';
                    }
                }
                else if (command == "up")
                {
                    if (row - 1 >= 0)
                    {
                        field[row, col] = '*';
                        row -= 1;
                        if (field[row, col] == 'c') coals--;
                        if (field[row, col] == 'e') end = true;
                        field[row, col] = 's';
                    }
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }
                if (end)
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }
            Console.WriteLine($"{coals} coals left. ({row}, {col})");
        }
    }
}
