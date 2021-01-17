using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[n];
                int[] input = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length; j++)
                    array[i][j] = input[j];
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                int row = int.Parse(data[1]);
                int cow = int.Parse(data[2]);
                int value = int.Parse(data[3]);
                if (row >= n || row < 0)
                    Console.WriteLine("Invalid coordinates");
                else
                {
                    if (cow >= array[row].Length || cow < 0)
                        Console.WriteLine("Invalid coordinates");
                    else
                        switch (data[0])
                        {
                            case "Add":
                                array[row][cow] += value;
                                break;
                            case "Subtract":
                                array[row][cow] -= value;
                                break;
                        }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
