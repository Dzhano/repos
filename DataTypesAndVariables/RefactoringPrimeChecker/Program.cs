using System;

namespace RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int doing = int.Parse(Console.ReadLine());
            for (int that = 2; that <= doing; that++)
            {
                bool prime = true;
                for (int cepitel = 2; cepitel < that; cepitel++)
                {
                    if (that % cepitel == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                Console.WriteLine($"{that} -> {prime.ToString().ToLower()}");
            }
        }
    }
}
