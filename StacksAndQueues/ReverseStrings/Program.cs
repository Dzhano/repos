using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> text = new Stack<char>();
            foreach (char item in input) text.Push(item);
            for (int i = 0; i < input.Length; i++)
                Console.Write(text.Pop());
        }
    }
}
