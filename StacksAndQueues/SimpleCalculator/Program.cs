using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> data = new Stack<string>(input.Reverse());
            while (data.Count > 1)
            {
                int num1 = int.Parse(data.Pop());
                string function = data.Pop();
                int num2 = int.Parse(data.Pop());
                switch (function)
                {
                    case "+":
                        data.Push((num1 + num2).ToString());
                        break;
                    case "-":
                        data.Push((num1 - num2).ToString());
                        break;
                }
            }
            Console.WriteLine(data.Pop());
        }
    }
}
