using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> names = new EqualityScale<string>("Dzhano", "Djano");
            Console.WriteLine(names.AreEqual()); // false
            names = new EqualityScale<string>("Dzhano", "Dzhano");
            Console.WriteLine(names.AreEqual()); // true
            EqualityScale<int> nums = new EqualityScale<int>(4, 4);
            Console.WriteLine(nums.AreEqual()); // true
            nums = new EqualityScale<int>(7, 2);
            Console.WriteLine(nums.AreEqual()); // false
        }
    }
}
