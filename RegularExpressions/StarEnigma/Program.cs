using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            Regex star = new Regex(@"[starSTAR]");
            Regex regex = new Regex(@"@(?<Name>[a-zA-z]+)[^@|:>-]*:\d+[^@|:>-]*!(?<TypeAttack>[AD])![^@|:>-]*->\d+");

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                StringBuilder input = new StringBuilder();
                input.Append(Console.ReadLine());
                MatchCollection stars = star.Matches(input.ToString());
                if (stars.Count > 0) 
                    for (int j = 0; j < input.Length; j++)
                    {
                        int asci = input[j];
                        asci -= stars.Count;
                        input[j] = (char)asci;
                    }
                Match match = regex.Match(input.ToString());
                if (match.Success)
                {
                    if (match.Groups["TypeAttack"].Value == "A")
                        attackedPlanets.Add(match.Groups["Name"].Value);
                    else if (match.Groups["TypeAttack"].Value == "D")
                        destroyedPlanets.Add(match.Groups["Name"].Value);
                }
            }

            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets) 
                Console.WriteLine($"-> {planet}");
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets)
                Console.WriteLine($"-> {planet}");
        }
    }
}
