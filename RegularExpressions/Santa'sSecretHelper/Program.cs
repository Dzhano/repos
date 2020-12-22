using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex santaRegex = new Regex(@"@(?<Name>[A-Za-z]+)[^@\-!:>]*!(?<Behaviour>[GN]{1})!");
            List<string> kids = new List<string>();
            int n = int.Parse(Console.ReadLine());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                StringBuilder code = new StringBuilder();
                foreach (char character in command) 
                    code.Append((char)(character - n));
                Match match = santaRegex.Match(code.ToString());
                if (match.Success) 
                    if (match.Groups["Behaviour"].Value == "G")
                        kids.Add(match.Groups["Name"].Value);
            }
            Console.WriteLine(string.Join(Environment.NewLine, kids));
        }
    }
}
