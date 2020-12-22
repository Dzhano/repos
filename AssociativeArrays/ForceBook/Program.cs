using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дава 60/100. Не знам къде е грешката.
            Dictionary<string, List<string>> forceSides
                = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] data = input.Split(" | ");
                    bool userExist = UserExist(forceSides, data[1]);
                    if (!userExist) forceSides.Add(data[0], new List<string>() { data[1] });
                }
                else if (input.Contains(" -> "))
                {
                    string[] data2 = input.Split(" -> ");
                    bool exist = UserExist(forceSides, data2[0]);
                    if (!exist)
                    {
                        if (forceSides.ContainsKey(data2[1])) forceSides[data2[1]].Add(data2[0]);
                        else forceSides.Add(data2[1], new List<string>() { data2[0] });
                        Console.WriteLine($"{data2[0]} joins the {data2[1]} side!");
                    }
                    else
                    {
                        if (forceSides.ContainsKey(data2[1])) 
                        {
                            foreach (var side in forceSides)
                                if (side.Value.Contains(data2[0]))
                                {
                                    if (side.Key != data2[1])
                                        side.Value.Remove(data2[0]);
                                }
                                else
                                {
                                    if (side.Key == data2[1])
                                    {
                                        side.Value.Add(data2[0]);
                                        Console.WriteLine($"{data2[0]} joins the {side.Key} side!");
                                    }
                                }
                        }
                        else forceSides.Add(data2[1], new List<string>() { data2[0] });
                    }
                }
            }
            Dictionary<string, List<string>> sortedForceSides = forceSides
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var side in sortedForceSides)
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    List<string> sortedSide = side.Value.OrderBy(x => x).ToList();
                    foreach (string user in sortedSide) Console.WriteLine($"! {user}");
                }
        }

        static bool UserExist (Dictionary<string, List<string>> forceSides, string person)
        {
            foreach (var user in forceSides)
                if (user.Value.Contains(person)) return true;
            return false;
        }
    }
}
