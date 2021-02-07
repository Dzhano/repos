using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader(@"../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"../../../output.txt"))
                {
                    int counter = 1;
                    string reader = stream.ReadLine();
                    while (reader != null)
                    {
                        writer.WriteLine($"{counter}. {reader}");
                        reader = stream.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
