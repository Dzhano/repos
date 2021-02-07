using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../../text.txt"))
            {
                using (StreamReader reader2 = new StreamReader(@"../../../words.txt"))
                {
                    string[] words = reader2.ReadLine().Split();
                    Dictionary<string, int> times = new Dictionary<string, int>();
                    foreach (string word in words) 
                        if (!times.ContainsKey(word)) times.Add(word, 0);
                    string text = string.Empty;
                    while ((text = reader.ReadLine()) != null)
                    {
                        string[] parts = text.ToLower()
                            .Split(new char[] { ',', '.', ' ', '!', '?', '-'}, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++) 
                            if (times.ContainsKey(parts[i])) times[parts[i]]++;
                    }
                    times = times.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    using (StreamWriter writer = new StreamWriter(@"../../../output.txt"))
                    {
                        foreach (var time in times)
                            writer.WriteLine($"{time.Key} - {time.Value}");
                    }
                }
            }
        }
    }
}
