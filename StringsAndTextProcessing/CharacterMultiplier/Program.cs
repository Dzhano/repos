using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            int result = 0;
            if (words[0].Length > words[1].Length) result = Result(result, words[1], words[0]);
            else result = Result(result, words[0], words[1]);
            Console.WriteLine(result);
        }

        static int Result(int result, string shorter, string longer)
        {
            for (int i = 0; i < shorter.Length; i++)
                result += shorter[i] * longer[i];
            for (int i = shorter.Length; i < longer.Length; i++)
                result += longer[i];
            return result;
        }
    }
}
