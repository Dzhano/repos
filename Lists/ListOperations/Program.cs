using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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
            while ((command = Console.ReadLine()) != "End")
            {
                string[] com = command.Split();

                switch (com[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(com[1]));
                        break;
                    case "Remove":
                        if (int.Parse(com[1]) >= numbers.Count || int.Parse(com[1]) < 0) Console.WriteLine("Invalid index");
                        else numbers.RemoveAt(int.Parse(com[1]));
                        break;
                    case "Insert":
                        if (int.Parse(com[2]) >= numbers.Count || int.Parse(com[2]) < 0) Console.WriteLine("Invalid index");
                        else numbers.Insert(int.Parse(com[2]), int.Parse(com[1]));
                        break;
                    case "Shift":
                        switch (com[1])
                        {
                            case "left":
                                for (int i = 0; i < int.Parse(com[2]); i++)
                                {
                                    int first = numbers[0];
                                    for (int u = 0; u < numbers.Count - 1; u++) numbers[u] = numbers[u + 1];
                                    numbers[numbers.Count - 1] = first;
                                }
                                break;
                            case "right":
                                for (int i = 0; i < int.Parse(com[2]); i++)
                                {
                                    int last = numbers[numbers.Count - 1];
                                    for (int f = numbers.Count - 1; f > 0; f--) numbers[f] = numbers[f - 1];
                                    numbers[0] = last;
                                }
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
