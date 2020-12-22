using System;
using System.Net.Http.Headers;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                count += VowelsCount(symbol);
            }
            Console.WriteLine(count);
        }

        static int VowelsCount(char symbol)
        {
            int count = 0;
            switch (symbol)
            {
                case 'a':
                    count = 1;
                    break;
                case 'e':
                    count = 1;
                    break;
                case 'i':
                    count = 1;
                    break;
                case 'o':
                    count = 1;
                    break;
                case 'u':
                    count = 1;
                    break;
                case 'y':
                    count = 1;
                    break;
            }
            return count;
        }
    }
}
