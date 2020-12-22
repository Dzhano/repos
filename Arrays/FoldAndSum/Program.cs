using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr1 = new int[array.Length / 4];
            int[] arr = new int[array.Length / 2];
            int[] arr2 = new int[array.Length / 4];
            int counter = 0;
            for (int i = arr1.Length - 1; i >= 0; i--)
            {
                arr1[i] = array[counter];
                counter++;
            }
            for (int p = 0; p < arr.Length; p++)
            {
                arr[p] = array[counter];
                counter++;
            }
            for (int u = arr2.Length - 1; u >= 0; u--)
            {
                arr2[u] = array[counter];
                counter++;
            }
            counter = 0;
            for (int j = 0; j < arr.Length / 2; j++)
            {
                arr[j] += arr1[counter];
                counter++;
            }
            counter = 0;
            for (int l = arr.Length / 2; l < arr.Length; l++)
            {
                arr[l] += arr2[counter];
                counter++;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
