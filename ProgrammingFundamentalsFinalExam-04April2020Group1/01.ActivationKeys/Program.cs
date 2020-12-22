using System;
using System.Text;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] command = input.Split(">>>");
                switch (command[0])
                {
                    case "Contains":
                        if (text.ToString().Contains(command[1])) Console.WriteLine($"{text} contains {command[1]}");
                        else Console.WriteLine("Substring not found!");
                        break;
                    case "Flip":
                        for (int i = int.Parse(command[2]); i < int.Parse(command[3]); i++)
                        {
                            if (command[1] == "Upper") 
                                text[i] = char.Parse(text[i].ToString().ToUpper());
                            else if (command[1] == "Lower") 
                                text[i] = char.Parse(text[i].ToString().ToLower());
                        }
                        Console.WriteLine(text);
                        break;
                    case "Slice":
                        text.Remove(int.Parse(command[1]), (int.Parse(command[2]) - int.Parse(command[1])));
                        Console.WriteLine(text);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
