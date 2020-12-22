using System;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            while ((line = Console.ReadLine()) != "end")
            {
                string reversed = string.Empty;
                for (int i = line.Length - 1; i >= 0; i--)
                    reversed += line[i];
                Console.WriteLine($"{line} = {reversed}");
            }
        }
    }
}
