using System;

namespace CustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(1); // 1
            stack.Push(2); // 1, 2
            stack.Push(3); // 1, 2, 3
            stack.Push(4); // 1, 2, 3, 4
            stack.Push(5); // 1, 2, 3, 4, 5

            Console.WriteLine(stack.Pop()); // 5   // 1, 2, 3, 4
            Console.WriteLine(stack.Peek()); // 4  // 1, 2, 3, 4
            stack.ForEach(x => Console.WriteLine(x)); // "1\n2\n3\n4"
            /*
            CustomList list = new CustomList();
            list.Add(1); // 1
            list.Add(2); // 1, 2
            list.Add(3); // 1, 2, 3
            list.Add(4); // 1, 2, 3, 4
            list.Add(5); // 1, 2, 3, 4, 5

            Console.WriteLine(list.RemoveAt(0)); // 1     // 2, 3, 4, 5
            Console.WriteLine(list.RemoveAt(1)); // 3     // 2, 4, 5
            list.Insert(1, 6); // 2, 6, 4, 5
            Console.WriteLine(list.Contains(5)); // true
            Console.WriteLine(list.Contains(1)); // false
            list.Swap(1, 3); // 2, 5, 4, 6
            list.Reverse(); // 6, 4, 5, 2
            Console.WriteLine(list.ToString()); // "6 4 5 2 "
            */
        }
    }
}
