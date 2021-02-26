using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Dzhano");
            list.Add("Djano");
            list.Add("17");
            Console.WriteLine(list.RandomString());
        }
    }
}
