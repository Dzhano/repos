using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
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
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == int.Parse(com[1])) numbers.RemoveAt(i);
                        }
                        numbers.Remove(int.Parse(com[1]));
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
