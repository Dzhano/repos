using System;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // For me this is more like a stack.
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            for (int i = 1; i <= 10; i++)
                doublyLinkedList.AddFirst(i);
            doublyLinkedList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
                doublyLinkedList.RemoveLast();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            for (int i = -1; i > -4; i--)
                doublyLinkedList.AddLast(i);
            doublyLinkedList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
                doublyLinkedList.RemoveFirst();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            doublyLinkedList.ForEachFromTail(x => Console.WriteLine(x));
            Console.WriteLine();
            int[] array = doublyLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
