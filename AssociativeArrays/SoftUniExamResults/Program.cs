using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants
                = new Dictionary<string, int>();
            Dictionary<string, int> languages
                = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] data = input.Split("-");
                if (data[1] == "banned") participants.Remove(data[0]);
                else
                {
                    if (participants.ContainsKey(data[0]))
                    {
                        if (participants[data[0]] < int.Parse(data[2]))
                            participants[data[0]] = int.Parse(data[2]);
                    }
                    else participants.Add(data[0], int.Parse(data[2]));

                    if (languages.ContainsKey(data[1])) languages[data[1]]++;
                    else languages.Add(data[1], 1);
                }
            }
            Dictionary<string, int> sortedParticipants = participants
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var participant in sortedParticipants) 
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            Dictionary<string, int> sortedLanguages = languages
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");
            foreach (var language in sortedLanguages)
                Console.WriteLine($"{language.Key} - {language.Value}");
        }
    }
}
