using System;
using System.ComponentModel.DataAnnotations;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            DataType(type);
        }

        static void DataType(string type)
        {
            switch (type)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine()) * 2;
                    Console.WriteLine(number);
                    break;
                case "real":
                    double num = double.Parse(Console.ReadLine()) * 1.5;
                    Console.WriteLine($"{num:F2}");
                    break;
                case "string":
                    string input = Console.ReadLine();
                    Console.WriteLine($"${input}$");
                    break;
            }
        }
    }
}
