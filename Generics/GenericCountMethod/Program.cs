using System;
using System.Collections.Generic;

namespace GenericCountMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }
            Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
            int count = GetGreater(boxes, box);
            Console.WriteLine(count);
        }

        private static int GetGreater<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;
            foreach (Box<T> item in boxes)
            {
                if (item.Value.CompareTo(box.Value) == 1)
                    count++;
            }
            return count;
        }
    }
}
