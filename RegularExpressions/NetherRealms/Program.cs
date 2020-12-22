using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regCharacters = new Regex(@"[^0-9+\-*\/.]");
            Regex regDigits = new Regex(@"[+-]?\d+\.?\d*");
            Regex signs = new Regex(@"[*\/]");
            List<string> participantDemons = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            participantDemons = participantDemons.OrderBy(x => x).ToList();
            foreach (string demon in participantDemons)
            {
                double health = 0;
                double damage = 0;
                MatchCollection matchHealth = regCharacters.Matches(demon);
                foreach (Match match in matchHealth) health += char.Parse(match.Value);
                MatchCollection digits = regDigits.Matches(demon);
                foreach (Match num in digits) damage += double.Parse(num.Value);
                if (damage != 0)
                {
                    MatchCollection commands = signs.Matches(demon);
                    foreach (Match sign in commands)
                    {
                        if (sign.Value == "*") damage *= 2;
                        else if (sign.Value == "/") damage /= 2;
                    }
                }
                Console.WriteLine($"{demon} - {health} health, {damage:F2} damage");
            }
        }
    }
}
