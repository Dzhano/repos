using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    class CustomStack
    {
        public CustomStack()
        {
            array = new int[InitialCapacity];
        }
        private int[] array;
        private const int InitialCapacity = 4;
        public int Count { get; private set; }


        public void Push(int element)
        {
            if (Count >= array.Length) 
            {
                int[] copy = new int[Count * 2];
                Array.Copy(array, copy, Count);
                array = copy;
            }
            array[Count++] = element;
        }

        public int Pop()
        {
            if (Count == 0) 
                throw new InvalidOperationException("CustomStack is empty");
            int value = array[Count - 1];
            array[--Count] = default;
            return value;
        }

        public int Peek()
        {
            if (Count == 0) 
                throw new InvalidOperationException("CustomStack is empty");
            return array[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
                action(array[i]);
        }
    }
}
