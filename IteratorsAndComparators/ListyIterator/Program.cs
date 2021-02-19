using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listyIterator));
                        break;
                }
            }
        }
    }
}
