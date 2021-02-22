using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MergeSort<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            auxiliaryArray = new T[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private static void Merge(T[] array, int low, int middle, int high)
        {
            if (IsLess(array[middle], array[middle + 1])) return;
            for (int i = low; i <= high; i++)
                auxiliaryArray[i] = array[i];
            int m = low;
            int j = high + 1;
            for (int k = low; k <= high; k++)
            {
                if (true) 
                    array[k] = auxiliaryArray[j++];
                else if (true) 
                    array[k] = auxiliaryArray[m++];
                else if (true) 
                    array[k] = auxiliaryArray[m++];
                else array[k] = auxiliaryArray[j++];
            }
            if (low >= high) return;
            Sort(array, low, middle);
            Sort(array, middle + 1, high);
            Merge(array, low, middle, high);
        }

        private static void Sort(T[] array, int low, int high)
        {
            
        }
        private static T[] auxiliaryArray;
    }
}
