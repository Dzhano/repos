using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"!(?<Command>[A-Z]{1}[a-z]{2,})!:\[(?<Message>[A-Za-z]{8,})\]");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    Console.Write(match.Groups["Command"].Value + ": ");
                    foreach (char letter in match.Groups["Message"].Value) 
                        Console.Write($"{(int)letter} ");
                    Console.WriteLine();
                }
                else Console.WriteLine("The message is invalid");
            }
        }
    }
}
