using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@#{1,}(?<Text>[A-Z]{1,}[A-Za-z0-9]{4,}[A-Z]{1,})@#{1,}");
            Regex numbers = new Regex(@"[0-9]");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                StringBuilder group = new StringBuilder();
                if (match.Success)
                {
                    foreach (char item in match.ToString()) 
                        if (item != '@' && item != '#')
                            if (numbers.IsMatch(item.ToString())) 
                                group.Append(item);
                    if (group.Length == 0) group.Append("00");
                    Console.WriteLine($"Product group: {group}");
                }
                else Console.WriteLine("Invalid barcode");
            }
        }
    }
}
