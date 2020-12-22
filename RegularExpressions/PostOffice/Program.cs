using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            // 90/100 в Judge
            Regex first = new Regex(@"([#*&$%])(?<Capitals>[A-Z]+)\1");
            Regex second = new Regex(@"(?<Capital>\d{2}):(?<LettersLength>\d{2})");
            Dictionary<char, int> capitals = new Dictionary<char, int>();
            string[] text = Console.ReadLine().Split("|");
            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    Match matchCapitals = first.Match(text[0]);
                    foreach (char letter in matchCapitals.Groups["Capitals"].Value.ToString())
                        capitals.Add(letter, 0);
                }
                else if (i == 1)
                {
                    MatchCollection matches = second.Matches(text[1]);
                    foreach (Match match in matches)
                    {
                        char key = (char)int.Parse(match.Groups["Capital"].Value.ToString());
                        if (capitals.ContainsKey(key))
                        {
                            if (capitals[key] < int.Parse
                                (match.Groups["LettersLength"].Value.ToString())) 
                                capitals[key] = int.Parse
                                (match.Groups["LettersLength"].Value.ToString());
                        }
                    }
                }
                else if (i == 2)
                {
                    string[] words = text[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words) 
                        if (capitals.ContainsKey(word[0]))
                        {
                            int length = capitals[word[0]];
                            if (word.Length == length + 1)
                                Console.WriteLine(word);
                        }
                }
            }
        }
    }
}
