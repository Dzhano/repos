using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                switch (nums[0])
                {
                    case 1:
                        numbers.Push(nums[1]);
                        break;
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count > 0) Console.WriteLine(numbers.Max());
                        break;
                    case 4:
                        if (numbers.Count > 0) Console.WriteLine(numbers.Min());
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
