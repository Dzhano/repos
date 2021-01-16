using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();
            Queue<string> songs = new Queue<string>(input);
            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Contains("Play")) songs.Dequeue();
                else if (command.Contains("Add"))
                {
                    string substring = command.Substring(4);
                    if (songs.Contains(substring))
                        Console.WriteLine($"{substring} is already contained!");
                    else songs.Enqueue(substring);
                }
                else if (command.Contains("Show"))
                    Console.WriteLine(string.Join(", ", songs));
            }
            Console.WriteLine("No more songs!");
        }
    }
}
