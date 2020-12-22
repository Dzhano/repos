using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                int number = int.Parse(command);
                string result = Palindrome(command);
                Console.WriteLine(result);
            }
        }

        static string Palindrome(string num)
        {
            int length = num.Length;
            string palindrome = "false";
            for (int i = 0; i < length; i++)
            {
                if (num[i] != num[length - 1 - i])
                {
                    return palindrome;
                }
            }
            palindrome = "true";
            return palindrome;
        }
    }
}
