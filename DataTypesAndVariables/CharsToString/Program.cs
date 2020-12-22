using System;

namespace CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char character = char.Parse(Console.ReadLine());
                text += character;
            }
            Console.WriteLine(text);
        }
    }
}
