using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^.*([@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}).*\1.*$";
            string patternSing = @"[@]|[#]|[$]|[\^]";

            var tickets = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            foreach (var item in tickets)
            {
                if (item.Length == 20)
                {
                    var match = Regex.Match(item, pattern);
                    if (match.Success)
                    {
                        int count = item.Count();
                        var leftPart = item.Substring(0, count / 2);
                        var rightPart = item.Substring(count / 2);

                        var matchesLeft = Regex.Matches(leftPart, patternSing);
                        var matchesRight = Regex.Matches(rightPart, patternSing);

                        if (matchesLeft.Count == matchesRight.Count)
                        {
                            int min = Math.Min(matchesLeft.Count, matchesRight.Count);
                            if (min == 10) Console.WriteLine($"ticket \"{item}\" - 10{matchesLeft[1]} Jackpot!");
                            else if (min >= 6 && min <= 9) Console.WriteLine($"ticket \"{item}\" - {min}{matchesLeft[1]}");
                            else Console.WriteLine($"ticket \"{item}\" - no match");
                        }
                        else Console.WriteLine($"ticket \"{item}\" - no match");
                    }
                    else Console.WriteLine($"ticket \"{item}\" - no match");
                }
                else Console.WriteLine("invalid ticket");
            }
        }
    }
}
