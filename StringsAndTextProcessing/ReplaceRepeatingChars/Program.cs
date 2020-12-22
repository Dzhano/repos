using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char letter = ' ';
            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0) letter = text[i];
                else
                {
                    if (letter == text[i])
                    {
                        text = text.Remove(i, 1);
                        i--;
                    }
                    else letter = text[i];
                }
            }
            Console.WriteLine(text);
        }
    }
}
