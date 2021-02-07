using System;
using System.Collections.Generic;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../../text.txt");
            List<char> symbols = new List<char>() {',', '.', '!', '?', '\'', '-' };
            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = 0;
                int symbolsCount = 0;
                foreach (char character in lines[i])
                {
                    if (char.IsLetter(character)) lettersCount++;
                    else if (symbols.Contains(character)) symbolsCount++;
                }
                Console.WriteLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
            }
        }
    }
}
