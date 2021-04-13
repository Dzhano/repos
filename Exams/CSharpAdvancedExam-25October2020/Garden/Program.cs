using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] c = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray(); 
            int n = c[0];
            int m = c[1];
            int[,] garden = new int[n, m];

            List<int[]> bloomCoordinates = new List<int[]>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinats = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                if (coordinats[0] >= n || coordinats[0] < 0 || coordinats[1] >= m || coordinats[1] < 0)
                    Console.WriteLine("Invalid coordinates.");
                else bloomCoordinates.Add(coordinats);
            }

            foreach (int[] item in bloomCoordinates)
            {
                for (int i = 0; i < m; i++) garden[item[0], i]++;
                for (int i = 0; i < n; i++) if (i != item[0]) garden[i, item[1]]++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write(garden[i,j] + " ");
                Console.WriteLine();
            }
        }
    }
}
