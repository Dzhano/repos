using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove()); // 3
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove()); // 5
            Console.WriteLine(box.Count);
        }
    }
}
