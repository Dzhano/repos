using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = string.Empty;
            string bestSequence = string.Empty;
            int sample = 0;
            int bestDNAsum = 0;
            int bestFirstLeftOne = 0;
            int bestCount = 0;
            int bestSample = 0;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                string sequence = command.Replace("!", "");
                string[] dnaParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);
                //111
                int count = 0;
                int dnaSum = 0;
                string bestSubSequence = string.Empty;
                sample++;
                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSequence = dnaPart;
                    }
                    dnaSum += dnaPart.Length;
                }
                int firstLeftOne = sequence.IndexOf(bestSubSequence);
                if (count > bestCount ||
                    (count == bestCount && firstLeftOne < bestFirstLeftOne) ||
                    (count == bestCount && firstLeftOne == bestFirstLeftOne && dnaSum > bestDNAsum) || sample == 1)
                {
                    bestCount = count;
                    bestSequence = sequence;
                    bestFirstLeftOne = firstLeftOne;
                    bestDNAsum = dnaSum;
                    bestSample = sample;
                }
            }
            char[] bestDNA = bestSequence.ToCharArray();
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestDNAsum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}
