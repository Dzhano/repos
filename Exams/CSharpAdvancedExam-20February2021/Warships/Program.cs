using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerOneShips = 0;
            int playerTwoShips = 0;

            int n = int.Parse(Console.ReadLine());
            List<int> coordinates = Console.ReadLine()
                .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < n; j++)
                {
                    if (input[j] == "<") playerOneShips++;
                    if (input[j] == ">") playerTwoShips++;
                    matrix[i, j] = char.Parse(input[j]);
                }
            }

            int destroyedShips = 0;
            bool draw = true;
            for (int i = 0; i < coordinates.Count; i += 2)
            {
                int col = coordinates[i];
                int row = coordinates[i + 1];
                if (col < 0 || col >= n || row >= n || row < 0) continue;

                switch (matrix[col,row])
                {
                    case '*':
                        matrix[col, row] = 'X';
                        break;
                    case '<':
                        matrix[col, row] = 'X';
                        playerOneShips--;
                        destroyedShips++;
                        break;
                    case '>':
                        matrix[col, row] = 'X';
                        playerTwoShips--;
                        destroyedShips++;
                        break;
                    case '#':
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if (j < 0 || j >= n) continue;
                            for (int k = row - 1; k <= row + 1; k++)
                            {
                                if (k >= n || k < 0) continue;
                                switch (matrix[j, k])
                                {
                                    case '<':
                                        playerOneShips--;
                                        destroyedShips++;
                                        break;
                                    case '>':
                                        playerTwoShips--;
                                        destroyedShips++;
                                        break;
                                }
                                matrix[j, k] = 'X';
                            }
                        }
                        break;
                }

                if (playerOneShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
                    draw = false;
                    break;
                }
                else if (playerTwoShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
                    draw = false;
                    break;
                }
            }

            if (draw) Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. " +
                $"Player Two has {playerTwoShips} ships left.");
        }
    }
}
