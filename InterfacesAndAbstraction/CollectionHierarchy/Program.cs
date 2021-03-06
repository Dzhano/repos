using CollectionHierarchy.MethodInterfaces;
using CollectionHierarchy.StringCollections;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removes = int.Parse(Console.ReadLine());

            List<IAdd> addLists = new List<IAdd>();
            addLists.Add(new AddCollection());
            addLists.Add(new AddRemoveCollection());
            addLists.Add(new MyList());

            foreach (var list in addLists)
            {
                foreach (string item in input) 
                    Console.Write(list.Add(item) + " ");
                Console.WriteLine();
            }

            List<IRemove> removeLists = new List<IRemove>() 
            { 
                (IRemove) addLists[1], 
                (IRemove) addLists[2] 
            };

            foreach (var list in removeLists)
            {
                for (int i = 0; i < removes; i++)
                    Console.Write(list.Remove() + " ");
                Console.WriteLine();
            }
        }
    }
}
