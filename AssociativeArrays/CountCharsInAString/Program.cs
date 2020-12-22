using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            string input = Console.ReadLine();
            foreach (char item in input)
                if (item != ' ')
                {
                    if (letters.ContainsKey(item)) letters[item]++;
                    else letters.Add(item, 1);
                }
            foreach (var letter in letters) Console.WriteLine($"{letter.Key} -> {letter.Value}");
        }
    }
}
