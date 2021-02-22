using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(array, key));
        }
    }

    public static class BinarySearch
    {
        public static int IndexOf(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;
                if (key < array[middle])
                    high = middle - 1;
                else if (key > array[middle])
                    low = middle + 1;
                else return middle;
            }
            return -1;
        }
    }
}
