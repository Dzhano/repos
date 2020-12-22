using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] oldArray = new int[n];
            for (int i = 1; i <= n; i++)
            {
                int[] array = new int[i];
                array[0] = 1;
                array[array.Length - 1] = 1;
                for (int j = 1; j < array.Length - 1; j++)
                {
                    array[j] = oldArray[j - 1] + oldArray[j];
                }
                oldArray = array;
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
