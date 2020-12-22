using System;
using System.Text;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double lenght = text.Length;
            Middle(text, lenght);
        }

        static void Middle(string text, double lenght)
        {
            if (lenght % 2 != 0)
            {
                double character = Math.Ceiling(lenght / 2);
                int c = (int)character;
                Console.WriteLine(text[c - 1]);
            }
            else
            {
                int c = (int)lenght / 2;
                StringBuilder character = new StringBuilder();
                character.Append(text[c - 1]);
                character.Append(text[c]);
                Console.WriteLine(character);
            }
        }
    }
}
