using System;
using System.Text;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder word = new StringBuilder();
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int position = letter + key;
                word.Append((char)position);
            }
            Console.WriteLine(word);
        }
    }
}
