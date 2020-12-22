using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b");
            string text = Console.ReadLine();
            MatchCollection matches = regex.Matches(text);
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
