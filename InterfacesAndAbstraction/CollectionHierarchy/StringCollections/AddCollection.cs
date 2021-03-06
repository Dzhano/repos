using CollectionHierarchy.MethodInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.StringCollections
{
    public class AddCollection : IAdd
    {
        private List<string> elements;
        private int index;

        public AddCollection()
        {
            elements = new List<string>();
            index = 0;
        }

        public int Add(string element)
        {
            elements.Add(element);
            return index++;
        }
    }
}
