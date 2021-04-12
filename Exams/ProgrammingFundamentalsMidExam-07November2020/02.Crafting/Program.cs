using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> particles = Console.ReadLine()
                .Split("|").ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] input = command.Split();
                switch (input[0])
                {
                   case "Move":
                        switch (input[1])
                        {
                            case "Left":
                                if (int.Parse(input[2]) >= 0 && int.Parse(input[2]) < particles.Count 
                                    && int.Parse(input[2]) - 1 >= 0 && int.Parse(input[2]) - 1 < particles.Count)
                                {
                                    string part = particles[int.Parse(input[2])];
                                    particles.RemoveAt(int.Parse(input[2]));
                                    particles.Insert(int.Parse(input[2]) - 1, part);
                                }
                                break;
                            case "Right":
                                if (int.Parse(input[2]) >= 0 && int.Parse(input[2]) < particles.Count
                                    && int.Parse(input[2]) + 1 >= 0 && int.Parse(input[2]) + 1 < particles.Count)
                                {
                                    string part = particles[int.Parse(input[2])];
                                    particles.RemoveAt(int.Parse(input[2]));
                                    particles.Insert(int.Parse(input[2]) + 1, part);
                                }
                                break;
                        }
                        break;
                    case "Check":
                        for (int i = 0; i < particles.Count; i++)
                        {
                            switch (input[1])
                            {
                                case "Even":
                                    if (i % 2 == 0) Console.Write($"{particles[i]} ");
                                    break;
                                case "Odd":
                                    if (i % 2 != 0) Console.Write($"{particles[i]} ");
                                    break;
                            }
                        }
                        Console.WriteLine();
                        break;
                }
            }
            Console.WriteLine($"You crafted {string.Join("", particles)}!");
        }
    }
}
