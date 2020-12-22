using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> dictionary =
                new Dictionary<string, int>();
            foreach (string input in words)
            {
                string word = input.ToLower();
                if (dictionary.ContainsKey(word)) dictionary[word]++;
                else dictionary.Add(word, 1);
            }
            foreach (var word in dictionary)
                if (word.Value % 2 != 0) Console.Write($"{word.Key} ");
        }
    }
}
