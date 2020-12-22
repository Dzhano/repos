using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int counter = 1;
            int maxCounter = 0;
            int number = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    counter++;
                }
                if (counter > maxCounter)
                {
                    number = nums[i - 1];
                    maxCounter = counter;
                }
                if (nums[i - 1] != nums[i])
                {
                    counter = 1;
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
