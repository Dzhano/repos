namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> parts = new Stack<char>();
            bool valid = true;
            foreach (char item in parentheses)
            {
                if (item == '(' || item == '{' || item == '[')
                    parts.Push(item);
                else
                {
                    if ((item == ')' || item == '}' || item == ']') && parts.Count == 0)
                    {
                        valid = false;
                        break;
                    }
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
            return valid;
        }
    }
}
