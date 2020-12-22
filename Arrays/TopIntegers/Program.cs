using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool big = true;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] >= nums[i])
                    {
                        big = false;
                        break;
                    }
                }
                if (big)
                {
                    Console.Write($"{nums[i]} ");
                }
                big = true;
            }
        }
    }
}
