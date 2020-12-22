using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, double> racers = new Dictionary<string, double>();
            Regex name = new Regex(@"[A-Za-z]");
            Regex digits = new Regex(@"[0-9]");
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder n = new StringBuilder();
                MatchCollection match = name.Matches(input);
                foreach (Match d in match) n.Append(d);
                if (people.Contains(n.ToString()))
                {
                    MatchCollection points = digits.Matches(input);
                    int poin = 0;
                    foreach (Match digit in points) poin += int.Parse(digit.Value);
                    if (racers.ContainsKey(n.ToString())) racers[n.ToString()] += poin;
                    else racers.Add(n.ToString(), poin);
                }
            }
            racers = racers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int counter = 1;
            foreach (var item in racers)
            {
                if (counter == 1) Console.WriteLine($"1st place: {item.Key}");
                else if (counter == 2) Console.WriteLine($"2nd place: {item.Key}");
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                    break;
                }
                counter++;
            }
        }
    }
}
