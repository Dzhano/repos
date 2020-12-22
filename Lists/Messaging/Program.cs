using System;
using System.Linq;
using System.Text;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split().ToArray();
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            StringBuilder message = new StringBuilder();
            foreach (string command in numbers)
            {
                int n = 0;
                for (int i = 0; i < command.Length; i++) n += int.Parse(command[i].ToString());
                while (n >= text.Length) n -= text.Length;
                message.Append(text[n]);
                text.Remove(n, 1);
            }
            Console.WriteLine(message);
        }
    }
}
