namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap() => heap = new List<T>();

        public int Size => heap.Count;

        public void Add(T element)
        {
            heap.Add(element);
            HeapifyUp(Size - 1);
        }

        public T Peek() 
        {
            if (Size > 0) return heap[0];
            else throw new InvalidOperationException();
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
    }
}
