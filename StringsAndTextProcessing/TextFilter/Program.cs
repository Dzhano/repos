using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (string word in words) 
                if (text.Contains(word))
                    text = text.Replace
                         (word, new string('*', word.Length));
            Console.WriteLine(text);
        }
    }
}
