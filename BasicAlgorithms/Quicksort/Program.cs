using System;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Quick
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort<T>(T[] a, int low, int high) where T : IComparable<T>
        {
            if (low >= high) return;
            int pivotIndex = Partition(a, low, high);
        }

        private static int Partition<T>(T[] a, int low, int high) where T : IComparable<T>
        {
            if (low >= high) return low;
            int i = low;
            int j = high + 1;
            while (true)
            {
                while () if (i == high) break;
                while () if (j == low) break;
                if (i >= j) break;
                Swap(a, i, j);
            }
            Swap(a, low, j);
            return j;
        }

        private static void Swap<T>(T[] a, int low, int j) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }
    }
}
