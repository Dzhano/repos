using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>(numbers);
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] data = command.Split();
                switch (data[0])
                {
                    case "add":
                        nums.Push(int.Parse(data[1]));
                        nums.Push(int.Parse(data[2]));
                        break;
                    case "remove":
                        if (int.Parse(data[1]) <= nums.Count) 
                            for (int i = 0; i < int.Parse(data[1]); i++) 
                                nums.Pop();
                        break;
                }
            }
            Console.WriteLine("Sum: " + nums.Sum());
        }
    }
}
