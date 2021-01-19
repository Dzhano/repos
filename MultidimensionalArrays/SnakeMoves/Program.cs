using System;
using System.Linq;
using System.Text;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int index = 0;
            for (int i = 0; i < size[0]; i++)
            {
                StringBuilder text = new StringBuilder();
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        text.Append(input[index]);
                        index++;
                        if (index == input.Length) index = 0;
                    }
                    Console.WriteLine(text);
                }
                else
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        string update = input[index] + text.ToString();
                        text.Clear();
                        text.Append(update);
                        index++;
                        if (index == input.Length) index = 0;
                    }
                    Console.WriteLine(text);
                }
            }
        }
    }
}
