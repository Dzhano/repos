using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int indexBeforeTheName = text.IndexOf('@');
                int indexAfterOfTheName = text.IndexOf('|');
                string name = text.Substring(indexBeforeTheName + 1, indexAfterOfTheName -
                    indexBeforeTheName - 1);

                int indexBeforeTheAge = text.IndexOf('#');
                int indexAfterTheAge = text.IndexOf('*');
                string age = text.Substring(indexBeforeTheAge + 1, indexAfterTheAge - indexBeforeTheAge - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
