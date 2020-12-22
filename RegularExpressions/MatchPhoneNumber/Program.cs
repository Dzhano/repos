using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\+359)(-| )2\2(\d{3})\2(\d{4})\b");
            string text = Console.ReadLine();
            MatchCollection phoneNumbers = regex.Matches(text);
            string[] phones = phoneNumbers
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
