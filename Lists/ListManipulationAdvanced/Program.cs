using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            bool change = false;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] com = command.Split();
                switch (com[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(com[1]));
                        change = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(com[1]));
                        change = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(com[1]));
                        change = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(com[2]), int.Parse(com[1]));
                        change = true;
                        break;
                    case "Contains":
                        Console.WriteLine(numbers.Contains(int.Parse(com[1])) ? "Yes" : "No such number");
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        switch (com[1])
                        {
                            case "<":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n < int.Parse(com[2]))));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n <= int.Parse(com[2]))));
                                break;
                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n > int.Parse(com[2]))));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n >= int.Parse(com[2]))));
                                break;
                        }
                        break;
                }
            }
            if (change) Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
