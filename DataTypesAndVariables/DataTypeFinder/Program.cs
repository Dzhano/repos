using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Дава 90/100 в Judge. Кодът не е мой, така че не знам къде е грешката.
            // Слагам го за да го имам.
            double number = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;
                bool isFloatingPoint = double.TryParse(Convert.ToString(input), out double floating);
                if (isFloatingPoint)
                {
                    number = double.Parse(input);
                    if (number % 1 != 0) Console.WriteLine($"{input} is floating point type");
                    else Console.WriteLine($"{input} is integer type");
                }
                bool isCharacters = char.TryParse(Convert.ToString(input), out char character);
                if (isCharacters)
                {
                    character = char.Parse(input);
                    if (!Char.IsDigit(character)) Console.WriteLine($"{input} is character type");
                }
                bool isBoolean = bool.TryParse(Convert.ToString(input), out bool Boolean);
                if (isBoolean) Console.WriteLine($"{input} is boolean type");
                if (!isFloatingPoint && !isCharacters && !isBoolean) Console.WriteLine($"{input} is string type");
            }
        }
    }
}
