using CollectionHierarchy.MethodInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.StringCollections
{
    public class MyList : IAdd, IRemove
    {
        private List<string> elements;

        public MyList()
        {
            elements = new List<string>();
        }

        public int Add(string element)
        {
            elements.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = elements[0];
            elements.RemoveAt(0);
            return element;
        }

        public int Used { get => elements.Count; }
    }
}
