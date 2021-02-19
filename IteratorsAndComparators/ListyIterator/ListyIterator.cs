using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> items)
        {
            elements = items;
            index = 0;
        }


        public bool Move()
        {
            if (!HasNext()) return false;
            index++;
            return true;
        }

        public bool HasNext() => index + 1 < elements.Count;

        public void Print()
        {
            if (elements.Count == 0) Console.WriteLine("Invalid Operation!");
            else Console.WriteLine(elements[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in elements)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
