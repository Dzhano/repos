using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            if (n > 0) arr1[0] = 1;
            if (n > 1) arr1[1] = 1;
            int[] arr2 = arr1;
            int[] arr = arr1;
            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr1[i - 1] + arr2[i - 2];
                arr1 = arr;
                arr2 = arr1;
            }
            Console.WriteLine(arr[n - 1]);
        }
    }
}
