using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] array = new double[n][];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                array[i] = new double[input.Length];
                for (int j = 0; j < input.Length; j++)
                    array[i][j] = input[j];
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (array[i].Length == array[i + 1].Length)
                {
                    for (int j = i; j < i + 2; j++)
                    {
                        for (int k = 0; k < array[j].Length; k++)
                            array[j][k] *= 2;
                    }
                }
                else
                {
                    for (int j = i; j < i + 2; j++)
                    {
                        for (int k = 0; k < array[j].Length; k++)
                            array[j][k] /= 2;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 4)
                {
                    if (data[0] == "Add" || data[0] == "Subtract")
                    {
                        int row = int.Parse(data[1]);
                        int col = int.Parse(data[2]);
                        double value = double.Parse(data[3]);
                        if (row >= 0 && row < array.Length 
                            && col >= 0 && col < array[row].Length)
                        {
                            switch (data[0])
                            {
                                case "Add":
                                    array[row][col] += value;
                                    break;
                                case "Subtract":
                                    array[row][col] -= value;
                                    break;
                            }
                        }
                    }
                }
            }
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < array[r].Length; c++)
                    Console.Write(array[r][c] + " ");
                Console.WriteLine();
            }
        }
    }
}
