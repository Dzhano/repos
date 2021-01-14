using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> data = new Stack<int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') data.Push(i);
                else if (input[i] == ')')
                {
                    int index = data.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1));
                }
            }
        }
    }
}
