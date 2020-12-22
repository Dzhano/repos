using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine();
            string text = Console.ReadLine();
            int n = text.IndexOf(remove);
            while (n != -1)
            {
                text = text.Remove(n, remove.Length);
                n = text.IndexOf(remove);
            }
            Console.WriteLine(text);
        }
    }
}
