using System;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int arCount = 0;
            int[] array2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int ar2Count = array2.Length - 1;
            int[] result = new int[Math.Min(array.Length, array2.Length) * 2];
            for (int i = 0; i < result.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = array[arCount];
                    arCount++;
                }
                else
                {
                    result[i] = array2[ar2Count];
                    ar2Count--;
                }
            }
            int a = 0;
            int b = 0;
            if (array.Length > array2.Length)
            {
                a = array[array.Length - 2];
                b = array[array.Length - 1];
            }
            else if(array.Length < array2.Length)
            {
                a = array2[0];
                b = array2[1];
            }
            int counter = 0;
            for (int l = 0; l < result.Length; l++)
                if (result[l] > Math.Min(a, b) && result[l] < Math.Max(a, b))
                    counter++;
            int[] final = new int[counter];
            counter = 0;
            for (int l = 0; l < result.Length; l++)
                if (result[l] > Math.Min(a, b) && result[l] < Math.Max(a, b))
                {
                    final[counter] = result[l];
                    counter++;
                }
            Array.Sort(final);
            Console.WriteLine(string.Join(" ", final));
        }
    }
}
