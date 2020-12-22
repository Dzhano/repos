using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "find")
            {
                if (numbers.Length < input.Length)
                {
                    StringBuilder text = new StringBuilder();
                    int counter = 0;
                    foreach (char item in input)
                    {
                        text.Append((char)(item - numbers[counter]));
                        counter++;
                        if (counter == numbers.Length) counter = 0;
                    }
                    string textSTR = text.ToString();
                    string type = textSTR.Substring(textSTR.IndexOf("&") + 1,
                        textSTR.LastIndexOf("&") - textSTR.IndexOf("&") - 1);
                    string cordinates = textSTR.Substring(textSTR.IndexOf("<") + 1,
                        textSTR.IndexOf(">") - textSTR.IndexOf("<") - 1);
                    Console.WriteLine($"Found {type} at {cordinates}");
                }
            }
        }
    }
}
