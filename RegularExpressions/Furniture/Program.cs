using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>\w+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");
            double totalMoney = 0;
            string input = Console.ReadLine();
            Console.WriteLine("Bought furniture:");
            while (input != "Purchase")
            {
                Match info = regex.Match(input);
                if (info.Success)
                {
                    Console.WriteLine(info.Groups["name"].Value);
                    totalMoney += double.Parse(info.Groups["price"].Value)
                        * int.Parse(info.Groups["quantity"].Value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalMoney:F2}");
        }
    }
}
