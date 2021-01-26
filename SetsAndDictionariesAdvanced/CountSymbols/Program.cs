using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            foreach (char symbol in input)
            {
                if (!symbols.ContainsKey(symbol))
                    symbols.Add(symbol, 0);
                symbols[symbol]++;
            }
            foreach (var symbol in symbols)
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}
