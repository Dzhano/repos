using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            string text = Console.ReadLine();
            MatchCollection dates = regex.Matches(text);
            foreach (Match date in dates) 
                Console.WriteLine($"Day: {date.Groups["day"]}, " +
                    $"Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
        }
    }
}
