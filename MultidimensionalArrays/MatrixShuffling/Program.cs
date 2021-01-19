using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size[1]; j++)
                    matrix[i, j] = input[j];
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 5)
                {
                    if (input[0] == "swap")
                    {
                        int row1 = int.Parse(input[1]);
                        int col1 = int.Parse(input[2]);
                        int row2 = int.Parse(input[3]);
                        int col2 = int.Parse(input[4]);
                        if (row1 < size[0] && row1 >= 0
                            && row2 < size[0] && row2 >= 0)
                        {
                            if (col1 < size[1] && col1 >= 0
                                && col2 < size[1] && col2 >= 0)
                            {
                                string num1 = matrix[row1, col1];
                                string num2 = matrix[row2, col2];
                                matrix[row1, col1] = num2;
                                matrix[row2, col2] = num1;
                                for (int i = 0; i < size[0]; i++)
                                {
                                    for (int k = 0; k < size[1]; k++) 
                                        Console.Write(matrix[i, k] + " ");
                                    Console.WriteLine();
                                }
                            }
                            else Console.WriteLine("Invalid input!");
                        }
                        else Console.WriteLine("Invalid input!");
                    }
                    else Console.WriteLine("Invalid input!");
                }
                else Console.WriteLine("Invalid input!");
            }
        }
    }
}
