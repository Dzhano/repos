using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(@"../../../words.txt");
            Dictionary<string, int> times = new Dictionary<string, int>();
            foreach (string word in words)
                if (!times.ContainsKey(word)) times.Add(word, 0);
            string[] texts = File.ReadAllLines(@"../../../../text.txt");
            foreach (string text in texts)
            {
                string[] parts = text.ToLower()
                            .Split(new char[] { ',', '.', ' ', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                    if (times.ContainsKey(parts[i])) times[parts[i]]++;
            }
            List<string> actualResultsText = times.Select(x => $"{x.Key} - {x.Value}").ToList();
            File.WriteAllLines(@"../../../actualResults.txt", actualResultsText);
        }
    }
}
