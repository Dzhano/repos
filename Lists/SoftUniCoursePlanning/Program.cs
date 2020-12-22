using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ")
                .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] com = command.Split(":");
                bool exerciseContains = lessons.Contains($"{com[1]}-Exercise");
                switch (com[0])
                {
                    case "Add":
                        if (!lessons.Contains(com[1])) lessons.Add(com[1]);
                        break;
                    case "Remove":
                        if (lessons.Contains(com[1]))
                        {
                            lessons.Remove(com[1]);
                            if (exerciseContains) lessons.Remove($"{com[1]}-Exercise");
                        }
                        break;
                    case "Insert":
                        if (!lessons.Contains(com[1])) lessons.Insert(int.Parse(com[2]), com[1]);
                        break;
                    case "Swap":
                        if (lessons.Contains(com[1]) && lessons.Contains(com[2]))
                        {
                            bool exerciseContains2 = lessons.Contains($"{com[2]}-Exercise");
                            int c1 = lessons.IndexOf(com[1]);
                            int c2 = lessons.IndexOf(com[2]);
                            lessons.Remove(com[1]);
                            lessons.Insert(c2, com[1]);
                            if (exerciseContains)
                            {
                                lessons.Remove($"{com[1]}-Exercise");
                                lessons.Insert(c2 + 1, $"{com[1]}-Exercise");
                            }
                            lessons.Remove(com[2]);
                            lessons.Insert(c1, com[2]);
                            if (exerciseContains2)
                            {
                                lessons.Remove($"{com[2]}-Exercise");
                                lessons.Insert(c1 + 1, $"{com[2]}-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        if (lessons.Contains(com[1]))
                        {
                            if (!exerciseContains)
                            {
                                int c = lessons.IndexOf(com[1]) + 1;
                                if (c >= lessons.Count) lessons.Add($"{com[1]}-Exercise");
                                else lessons.Insert(c, $"{com[1]}-Exercise");
                            }
                        }
                        else
                        {
                            lessons.Add(com[1]);
                            lessons.Add($"{com[1]}-Exercise");
                        }
                        break;
                }
            }
            for (int i = 0; i < lessons.Count; i++) Console.WriteLine($"{i + 1}.{lessons[i]}");
        }
    }
}
