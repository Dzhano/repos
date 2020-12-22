using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Не знам защо не работи тук. В Judge дава 100/100.
            // Сигурно някакъв проблем с програмата.
            Dictionary<string, int> dictionary
                = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                int price = int.Parse(Console.ReadLine());
                if (dictionary.ContainsKey(input)) dictionary[input] += price;
                else dictionary.Add(input, price);
            }
            foreach (var metal in dictionary) Console.WriteLine($"{metal.Key} -> {metal.Value}");
        }
    }
}
