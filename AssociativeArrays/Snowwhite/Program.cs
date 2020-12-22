using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite //Снежанка
{
    class Program
    {
        static void Main(string[] args)
        {
            // Не знам къде е грешката.
            // Дава 70/100 в Judge.
            // Знам че е много дълъг и разхвърлен и някои неща се повтарят много 
                //(не са ни учили как да връщаме 2 или повече неща с методи), но нямах избор.
            Dictionary<int, Dictionary<string, List<string>>> dwarfs
                = new Dictionary<int, Dictionary<string, List<string>>>();
            Dictionary<string, List<string>> people
                = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] data = input.Split(" <:> ");
                bool later = false;
                bool noNeed = false;
                bool doIt = false;
                if (people.ContainsKey(data[1]))
                {
                    if (people[data[1]].Contains(data[0]))
                    {
                        foreach (var physic in dwarfs)
                        {
                            foreach (string dwarf in physic.Value[data[1]])
                            {
                                if (dwarf == data[0])
                                {
                                    if (physic.Key < int.Parse(data[2]))
                                    {
                                        physic.Value[data[1]].Remove(dwarf);
                                        later = true;
                                        doIt = true;
                                        break;
                                    }
                                    else
                                    {
                                        noNeed = true;
                                        later = true;
                                        break;
                                    }
                                }
                            }
                            if (later) break;
                        }
                        if (noNeed) break;
                    }
                    else
                    {
                        if (dwarfs.ContainsKey(int.Parse(data[2])))
                        {
                            if (dwarfs[int.Parse(data[2])].ContainsKey(data[1]))
                            {
                                if (!dwarfs[int.Parse(data[2])][data[1]].Contains(data[0]))
                                {
                                    dwarfs[int.Parse(data[2])][data[1]].Add(data[0]);
                                    if (people.ContainsKey(data[1]))
                                    {
                                        if (!people[data[1]].Contains(data[0]))
                                            people[data[1]].Add(data[0]);
                                    }
                                    else people.Add(data[1], new List<string>() { data[0] });
                                }
                            }
                            else dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                        }
                        else
                        {
                            dwarfs.Add(int.Parse(data[2]), new Dictionary<string, List<string>>());
                            dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                            if (people.ContainsKey(data[1]))
                            {
                                if (!people[data[1]].Contains(data[0]))
                                    people[data[1]].Add(data[0]);
                            }
                            else people.Add(data[1], new List<string>() { data[0] });
                        }
                    }
                }
                else
                {
                    if (dwarfs.ContainsKey(int.Parse(data[2])))
                    {
                        if (dwarfs[int.Parse(data[2])].ContainsKey(data[1]))
                        {
                            if (!dwarfs[int.Parse(data[2])][data[1]].Contains(data[0]))
                            {
                                dwarfs[int.Parse(data[2])][data[1]].Add(data[0]);
                                if (people.ContainsKey(data[1]))
                                {
                                    if (!people[data[1]].Contains(data[0]))
                                        people[data[1]].Add(data[0]);
                                }
                                else people.Add(data[1], new List<string>() { data[0] });
                            }
                        }
                        else dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                    }
                    else
                    {
                        dwarfs.Add(int.Parse(data[2]), new Dictionary<string, List<string>>());
                        dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                        if (people.ContainsKey(data[1]))
                        {
                            if (!people[data[1]].Contains(data[0]))
                                people[data[1]].Add(data[0]);
                        }
                        else people.Add(data[1], new List<string>() { data[0] });
                    }
                }
                if (doIt)
                {
                    if (dwarfs.ContainsKey(int.Parse(data[2])))
                    {
                        if (dwarfs[int.Parse(data[2])].ContainsKey(data[1]))
                        {
                            if (!dwarfs[int.Parse(data[2])][data[1]].Contains(data[0]))
                            {
                                dwarfs[int.Parse(data[2])][data[1]].Add(data[0]);
                                if (people.ContainsKey(data[1]))
                                {
                                    if (!people[data[1]].Contains(data[0]))
                                        people[data[1]].Add(data[0]);
                                }
                                else people.Add(data[1], new List<string>() { data[0] });
                            }
                        }
                        else dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                    }
                    else
                    {
                        dwarfs.Add(int.Parse(data[2]), new Dictionary<string, List<string>>());
                        dwarfs[int.Parse(data[2])].Add(data[1], new List<string>() { data[0] });
                        if (people.ContainsKey(data[1]))
                        {
                            if (!people[data[1]].Contains(data[0]))
                                people[data[1]].Add(data[0]);
                        }
                        else people.Add(data[1], new List<string>() { data[0] });
                    }
                }
            }
            Dictionary<int, Dictionary<string, List<string>>> sortedDwarfs =
                dwarfs.OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var physics in sortedDwarfs)
            {
                Dictionary<string, List<string>> sortedPhysics =
                    physics.Value.OrderByDescending(x => x.Value.Count)
                    .ToDictionary(x => x.Key, x => x.Value);
                foreach (var color in sortedPhysics)
                    foreach (string dwarf in color.Value)
                        Console.WriteLine($"({color.Key}) {dwarf} <-> {physics.Key}");
            }
        }
    }
}