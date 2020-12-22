using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            GetMax(type);
        }

        static void GetMax(string type)
        {
            switch (type)
            {
                case "int":
                    int num = int.Parse(Console.ReadLine());
                    int number = int.Parse(Console.ReadLine());
                    if (num > number)
                    {
                        Console.WriteLine(num);
                    }
                    else
                    {
                        Console.WriteLine(number);
                    }
                    break;
                case "char":
                    char sym1 = char.Parse(Console.ReadLine());
                    char sym2 = char.Parse(Console.ReadLine());
                    if (sym1 > sym2)
                    {
                        Console.WriteLine(sym1);
                    }
                    else
                    {
                        Console.WriteLine(sym2);
                    }
                    break;
                case "string":
                    string text1 = Console.ReadLine();
                    string text2 = Console.ReadLine();
                    int compare = text1.CompareTo(text2);
                    if (compare > 0)
                    {
                        Console.WriteLine(text1);
                    }
                    else
                    {
                        Console.WriteLine(text2);
                    }
                    break;
            }
        }
    }
}
