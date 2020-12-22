using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Не успях да реша задачата :( https://judge.softuni.bg/Contests/Compete/Index/1206#9
            int[] field = new int[int.Parse(Console.ReadLine())];
            int[] initialIndexes = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = 0;
                foreach (var item in initialIndexes)
                {
                    if (item == i)
                    {
                        field[i] = 1;
                        break;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] flying = command.Split();
                int ladybug = int.Parse(flying[0]);
                int length = int.Parse(flying[2]);
                if (flying[1] == "right")
                {
                    if (ladybug + length + 1 < field.Length)
                    {
                        field[ladybug + length] += 1;
                        if (field[ladybug + length] == 2)
                        {
                            int counter = 0;
                            do
                            {
                                counter += length;
                                field[ladybug + length + counter - 1] -= 1;
                                if (ladybug + length + counter + 1 > field.Length)
                                {
                                    break;
                                }
                                field[ladybug + length + counter] += 1;
                            } while (field[ladybug + length + counter] != 1);
                        }
                    }
                    field[ladybug] -= 1;
                }
                else if(flying[1] == "left")
                {
                    if (ladybug - length >= 0)
                    {
                        field[ladybug - length] += 1;
                        if (field[ladybug - length] == 2)
                        {
                            int counter = 0;
                            do
                            {
                                counter += length;
                                field[ladybug - length - counter + 1] -= 1;
                                if (ladybug - length - counter + 1 <= 0)
                                {
                                    break;
                                }
                                field[ladybug - length - counter] += 1;
                            } while (field[ladybug - length - counter] != 1);
                        }
                    }
                    field[ladybug] -= 1;
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
