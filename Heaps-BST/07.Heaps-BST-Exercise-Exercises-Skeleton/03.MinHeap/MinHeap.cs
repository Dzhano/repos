namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap() => this.elements = new List<T>();

        public int Size => elements.Count;

        public T Dequeue()
        {
            if (Size > 0)
            {
                T returned = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);

                HeapifyDown(0);

                return returned;
            }
            else throw new InvalidOperationException();
        }

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(Size - 1);
        }

        public T Peek()
        {
            if (Size > 0) return elements[0];
            else throw new InvalidOperationException();
        }

        
        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && elements[index].CompareTo(elements[parentIndex]) < 0)
            {
                T temp = elements[index];
                elements[index] = elements[parentIndex];
                elements[parentIndex] = temp;

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        
        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= elements.Count) return;
            if ((rightChildIndex < elements.Count) && elements[leftChildIndex].CompareTo(elements[rightChildIndex]) > 0)
                maxChildIndex = rightChildIndex;

            if (elements[index].CompareTo(elements[maxChildIndex]) > 0)
            {
                T temp = elements[index];
                elements[index] = elements[maxChildIndex];
                elements[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }
         
    }
}
