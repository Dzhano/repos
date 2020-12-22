using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int a = rnd.Next(0, words.Length);
                string b = words[i];
                words[i] = words[a];
                words[a] = b;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
