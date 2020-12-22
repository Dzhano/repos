using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] com = command.Split();
                switch (com[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(com[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(com[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(com[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(com[2]), int.Parse(com[1]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
