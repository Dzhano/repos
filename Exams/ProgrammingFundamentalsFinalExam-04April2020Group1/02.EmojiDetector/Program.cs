using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(\*\*|\:\:)(?<Name>[A-Z]{1}[a-z]{2,})\1");
            Regex numbers = new Regex(@"[0-9]");
            MatchCollection match = regex.Matches(input);
            MatchCollection digits = numbers.Matches(input);
            BigInteger coolThreshold = 1;
            foreach (Match num in digits) coolThreshold *= int.Parse(num.ToString());
            List<string> coolMatches = new List<string>();
            foreach (Match item in match)
            {
                BigInteger cool = 0;
                string name = item.ToString();
                for (int i = 2; i < name.Length - 2; i++) cool += name[i];
                if (cool >= coolThreshold) coolMatches.Add(name);
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{match.Count} emojis found in the text. The cool ones are:");
            if (coolMatches.Count > 0) 
                Console.WriteLine(string.Join(Environment.NewLine, coolMatches));
        }
    }
}
