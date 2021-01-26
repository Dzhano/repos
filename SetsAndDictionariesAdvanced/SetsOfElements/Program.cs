using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            HashSet<int> n = new HashSet<int>();
            for (int i = 0; i < num[0]; i++)
                n.Add(int.Parse(Console.ReadLine()));
            HashSet<int> m = new HashSet<int>();
            for (int i = 0; i < num[1]; i++)
                m.Add(int.Parse(Console.ReadLine()));
            HashSet<int> l = new HashSet<int>();
            foreach (int item in n) if (m.Contains(item)) l.Add(item);
            Console.WriteLine(string.Join(" ", l));
        }
    }
}
