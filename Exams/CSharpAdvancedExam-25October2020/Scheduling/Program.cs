using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] threadsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> threads = new Queue<int>(threadsInput);
            Stack<int> tasks = new Stack<int>(tasksInput);
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int heroThread = 0;

            while (true)
            {
                int thread = threads.Peek();
                int task = tasks.Pop();

                if (task == taskToBeKilled)
                {
                    heroThread = thread;
                    break;
                }

                if (thread < task) tasks.Push(task);
                threads.Dequeue();
            }

            Console.WriteLine($"Thread with value {heroThread} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
