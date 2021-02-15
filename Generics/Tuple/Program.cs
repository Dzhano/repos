using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");
            List<string> town = data.Skip(3).ToList();
            Threeuple<string, string, string> tupleOne 
                = new Threeuple<string, string, string>($"{data[0]} {data[1]}", data[2], string.Join(" ", town));

            string[] data2 = Console.ReadLine().Split(" ");
            Threeuple<string, int, bool> tupleTwo
                = new Threeuple<string, int, bool>(data2[0], int.Parse(data2[1]), data2[2] == "drunk" ? true : false);

            string[] data3 = Console.ReadLine().Split(" ");
            Threeuple<string, double, string> tupleThree 
                = new Threeuple<string, double, string>(data3[0], double.Parse(data3[1]), data3[2]);

            /*
            string[] data = Console.ReadLine().Split(" ");
            CustomTuple<string, string> tupleOne = new CustomTuple<string, string>($"{data[0]} {data[1]}", data[2]);

            string[] data2 = Console.ReadLine().Split(" ");
            CustomTuple<string, int> tupleTwo = new CustomTuple<string, int>(data2[0], int.Parse(data2[1]));

            string[] data3 = Console.ReadLine().Split(" ");
            CustomTuple<int, double> tupleThree = new CustomTuple<int, double>(int.Parse(data3[0]), double.Parse(data3[1]));
            */
            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }
    }
}
