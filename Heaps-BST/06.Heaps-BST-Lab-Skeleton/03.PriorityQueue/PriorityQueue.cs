namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue() => heap = new List<T>();

        public int Size => heap.Count;

        public T Dequeue()
        {
            if (Size > 0)
            {
                T returned = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                HeapifyDown(0);

                return returned;
            }
            else throw new InvalidOperationException();
        }

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

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count) return;
            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
                maxChildIndex = rightChildIndex;

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }
    }
}
