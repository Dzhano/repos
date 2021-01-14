using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNums = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            foreach (int item in arrNums)
            {
                if (item % 2 == 0)
                    numbers.Enqueue(item);
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
