using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Yacht
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int speed = int.Parse(Console.ReadLine());
            int maxSpeed = int.Parse(Console.ReadLine());

            List<int> checkpointNumbers = new List<int>();
            List<int> checkpointSpeeds = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (speed + nums[i] <= maxSpeed)
                {
                    speed += nums[i];
                }
                else if (speed - nums[i] >= 0)
                {
                    speed -= nums[i];
                }
                else if (i == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                else
                {
                    i = checkpointSpeeds[checkpointSpeeds.Count - 1];
                }
            }
            Console.WriteLine(speed);
        }
    }
}
