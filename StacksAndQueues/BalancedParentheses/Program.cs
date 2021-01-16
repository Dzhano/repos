using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parts = new Stack<char>();
            string parentheses = Console.ReadLine();
            bool valid = true;
            foreach (char item in parentheses)
            {
                if (item == '(' || item == '{' || item == '[')
                    parts.Push(item);
                else
                {
                    bool firstvalid = item == ')' && parts.Pop() == '(';
                    bool secondvalid = item == '}' && parts.Pop() == '{';
                    bool thirdvalid = item == ']' && parts.Pop() == '[';
                    if (!firstvalid && !secondvalid && !thirdvalid)
                    {
                        valid = false;
                        break;
                    }
                    // Това е кода на лектора Слави Капсалов.
                    // Запазих го понеже работи по същия принцип като моя, но просто е по-къс.
                    // Не знам къде е грешката в Judge. Дава 75/100.
                }
            }
            if (valid) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
