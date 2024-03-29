﻿using System;
using System.Linq;

namespace Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                if (i % 2 == 0)
                {
                    arr1[i] = nums[0];
                    arr2[i] = nums[1];
                }
                else
                {
                    arr2[i] = nums[0];
                    arr1[i] = nums[1];
                }
            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
