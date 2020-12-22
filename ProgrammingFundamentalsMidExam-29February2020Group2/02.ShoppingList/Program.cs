using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().
                Split("!").ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] data = command.Split();
                switch (data[0])
                {
                    case "Urgent":
                        if (!groceries.Contains(data[1])) groceries.Insert(0, data[1]);
                        break;
                    case "Unnecessary":
                        if (groceries.Contains(data[1])) groceries.Remove(data[1]);
                        break;
                    case "Correct":
                        if (groceries.Contains(data[1]))
                        {
                            int i = groceries.FindIndex(x => x == data[1]);
                            // Друг начин: //for (int i = 0; i < groceries.Count; i++)
                                              //if (groceries[i] == data[1])
                            groceries[i] = data[2];
                        }
                        break;
                    case "Rearrange":
                        if (groceries.Contains(data[1]))
                        {
                            groceries.Remove(data[1]);
                            groceries.Add(data[1]);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
