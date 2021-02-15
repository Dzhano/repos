using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethod
{
    public class GenericMethod<T>
    {
        public GenericMethod()
        {
            elements = new List<T>();
        }
        private List<T> elements;

        public void Add(T element)
        {
            elements.Add(element);
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T first = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = first;
        }
        public void Print()
        {
            foreach (T item in elements)
            {
                Type valueType = item.GetType();
                Console.WriteLine($"{valueType.FullName}: {item}");
            }
        }
    }
}
