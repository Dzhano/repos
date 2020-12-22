using System;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morse = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder text = new StringBuilder();
            foreach (string symbol in morse)
            {
                if (symbol == ".-") text.Append("A");
                else if (symbol == "-...") text.Append("B");
                else if (symbol == "-.-.") text.Append("C");
                else if (symbol == "-..") text.Append("D");
                else if (symbol == ".") text.Append("E");
                else if (symbol == "..-.") text.Append("F");
                else if (symbol == "--.") text.Append("G");
                else if (symbol == "....") text.Append("H");
                else if (symbol == "..") text.Append("I");
                else if (symbol == ".---") text.Append("J");
                else if (symbol == "-.-") text.Append("K");
                else if (symbol == ".-..") text.Append("L");
                else if (symbol == "--") text.Append("M");
                else if (symbol == "-.") text.Append("N");
                else if (symbol == "---") text.Append("O");
                else if (symbol == ".--.") text.Append("P");
                else if (symbol == "--.-") text.Append("Q");
                else if (symbol == ".-.") text.Append("R");
                else if (symbol == "...") text.Append("S");
                else if (symbol == "-") text.Append("T");
                else if (symbol == "..-") text.Append("U");
                else if (symbol == "...-") text.Append("V");
                else if (symbol == ".--") text.Append("W");
                else if (symbol == "-..-") text.Append("X");
                else if (symbol == "-.--") text.Append("Y");
                else if (symbol == "--..") text.Append("Z");
                else if (symbol == "|") text.Append(" ");
            }
            Console.WriteLine(text);
        }
    }
}