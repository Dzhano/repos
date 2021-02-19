using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "Push":
                        stack.Push(data.Skip(1).ToList());
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
