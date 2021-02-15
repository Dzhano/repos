using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class StartUp
    {

        // Generic Box of Integer
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                // Box<string> box = new Box<string>(Console.ReadLine());
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box.ToString());
            }
        }

        /*
        // Generic Swap Method Strings
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes = SwapIndexes(boxes, indexes[0], indexes[1]);
            foreach (Box<string> box in boxes)
                Console.WriteLine(box.ToString());
        }

        static List<Box<string>> SwapIndexes(List<Box<string>> boxes, int firstIndex, int secondIndex)
        {
            Box<string> box = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = box;
            return boxes;
        }*/

        /*
        // Generic Swap Method Integers
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes = SwapIndexes(boxes, indexes[0], indexes[1]);
            foreach (Box<int> box in boxes)
                Console.WriteLine(box.ToString());
        }

        static List<Box<int>> SwapIndexes(List<Box<int>> boxes, int firstIndex, int secondIndex)
        {
            Box<int> box = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = box;
            return boxes;
        }*/
    }
}
