using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> data = new Stack<char>();
            int n = int.Parse(Console.ReadLine());
            List<Stack<char>> lastSaved = new List<Stack<char>>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "1":
                        Stack<char> newStack = Previous(data);
                        lastSaved.Add(newStack);
                        foreach (char item in command[1])
                            data.Push(item);
                        break;
                    case "2":
                        Stack<char> newStack2 = Previous(data);
                        lastSaved.Add(newStack2);
                        if (int.Parse(command[1]) >= data.Count)
                            data.Clear();
                        else
                            for (int j = 0; j < int.Parse(command[1]); j++)
                                data.Pop();
                        break;
                    case "3":
                        int position = int.Parse(command[1]) - 1;
                        StringBuilder text = new StringBuilder();
                        foreach (char item in data)
                            text.Append(item);
                        string textT = text.ToString();
                        StringBuilder text2 = new StringBuilder();
                        foreach (char item in textT.Reverse())
                            text2.Append(item);
                        Console.WriteLine(text2[position]);
                        break;
                    case "4":
                        data = lastSaved[lastSaved.Count - 1];
                        lastSaved.RemoveAt(lastSaved.Count - 1);
                        break;
                }
            }
        }

        static Stack<char> Previous(Stack<char> data)
        {
            Stack<char> newStack = new Stack<char>();
            foreach (char item in data.Reverse())
                newStack.Push(item);
            return newStack;
        }
    }
}
