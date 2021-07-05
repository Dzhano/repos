using System;

namespace _6.TheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string name = Console.ReadLine();

            if (input.Length > name.Length || input.Length < name.Length)
            {
                Console.WriteLine("The name cannot be transformed!");
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!name.Contains(input[i])) 
                {
                    Console.WriteLine("The name cannot be transformed!");
                    return;
                }
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!input.Contains(name[i]))
                {
                    Console.WriteLine("The name cannot be transformed!");
                    return;
                }
            }


        }
    }
}
