using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                switch (data[0])
                {
                    case "Shoot":
                        if (int.Parse(data[1]) < targets.Count && int.Parse(data[1]) >= 0)
                            targets[int.Parse(data[1])] -= int.Parse(data[2]);
                        else continue;
                        if (targets[int.Parse(data[1])] <= 0) targets.RemoveAt(int.Parse(data[1]));
                        break;
                    case "Add":
                        if (int.Parse(data[1]) < 0 || int.Parse(data[1]) >= targets.Count) 
                            Console.WriteLine("Invalid placement!");
                        else targets.Insert(int.Parse(data[1]), int.Parse(data[2]));
                        break;
                    case "Strike":
                        if (int.Parse(data[1]) - int.Parse(data[2]) < 0 ||
                            int.Parse(data[1]) + int.Parse(data[2]) >= targets.Count) 
                            Console.WriteLine("Strike missed!");
                        else
                        {
                            int radius = int.Parse(data[2]) * 2 + 1;
                            if (int.Parse(data[1]) - int.Parse(data[2]) < 0)
                            {
                                int extraRadius = 0 - (int.Parse(data[1]) - int.Parse(data[2]));
                                radius -= extraRadius;
                                targets.RemoveRange(0, radius);
                            }
                            else targets.RemoveRange(int.Parse(data[1]) - int.Parse(data[2]), int.Parse(data[2]) * 2 + 1);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
