using System;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> uppercaseWord = x => char.IsUpper(x[0]);
            foreach (string word in words)
                if (uppercaseWord(word))
                    Console.WriteLine(word);
        }
    }
}
