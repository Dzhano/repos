using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            // 75/100 в Judge
            Regex regexEmail = new Regex(@"[a-z0-9]+[.\-_]?[a-z0-9]+@[a-z]+[.\-]?[a-z]+\.[a-z]+\.?[a-z]+");
            string[] text = Console.ReadLine().Split();
            foreach (string word in text)
            {
                Match email = regexEmail.Match(word);
                if (email.Success) Console.WriteLine(email.Value);
            }
        }
    }
}
