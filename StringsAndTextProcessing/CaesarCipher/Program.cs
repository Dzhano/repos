using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder cipher = new StringBuilder();
            foreach (char item in text) cipher.Append((char)(item + 3));
            Console.WriteLine(cipher);
        }
    }
}
