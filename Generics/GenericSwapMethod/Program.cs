using System;
using System.Linq;

namespace GenericSwapMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // GenericMethod<string> method = new GenericMethod<string>();
            GenericMethod<int> method = new GenericMethod<int>();
            for (int i = 0; i < n; i++)
            {
                // method.Add(Console.ReadLine());
                method.Add(int.Parse(Console.ReadLine()));
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            method.Swap(indexes[0], indexes[1]);
            method.Print();
        }
    }
}
