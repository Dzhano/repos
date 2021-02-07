using System;
using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader(@"../../../input.txt"))
            {
                int counter = 0;
                string reader = stream.ReadLine();
                while (reader != null)
                {
                    if (counter % 2 != 0)
                        Console.WriteLine(reader);
                    reader = stream.ReadLine();
                    counter++;
                }
            }
        }
    }
}
