using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../../text.txt"))
            {
                int counter = 0;
                string text = string.Empty;
                while ((text = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        text = text.Replace('-', '@');
                        text = text.Replace(',', '@');
                        text = text.Replace('.', '@');
                        text = text.Replace('!', '@');
                        text = text.Replace('?', '@');
                        string[] parts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(string.Join(" ", parts.Reverse()));
                    }
                }
            }
        }
    }
}
