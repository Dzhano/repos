using System;
using System.Text;

namespace Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                switch (input[0])
                {
                    case "Translate":
                        text.Replace(input[1], input[2]);
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        bool includes = text.ToString().Contains(input[1]);
                        Console.WriteLine(includes);
                        break;
                    case "Start":
                        bool start = text.ToString().StartsWith(input[1]);
                        Console.WriteLine(start);
                        break;
                    case "Lowercase":
                        string newText = text.ToString().ToLower();
                        text.Remove(0, text.Length);
                        text.Append(newText);
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        Console.WriteLine(text.ToString().LastIndexOf(input[1]));
                        break;
                    case "Remove":
                        text.Remove(int.Parse(input[1]), int.Parse(input[2]));
                        Console.WriteLine(text);
                        break;
                }
            }
        }
    }
}
