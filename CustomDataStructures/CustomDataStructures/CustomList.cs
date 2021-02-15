using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    class CustomList
    {
        public CustomList()
        {
            array = new int[InitialCapacity];
        }
        private int[] array;
        private const int InitialCapacity = 2;
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                InOrOutOfRange(index);
                return array[index];
            }
            set
            {
                InOrOutOfRange(index);
                array[index] = value;
            }
        }


        public void Add(int element)
        {
            if (Count >= array.Length) Resize();
            array[Count++] = element;
        }

        public int RemoveAt(int index)
        {
            InOrOutOfRange(index);
            int value = array[index];
            array[index] = default;
            Shift(index);
            if (--Count == array.Length / 4) Shrink();
            return value;
        }

        public void Insert(int index, int item)
        {
            if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            if (Count >= array.Length) Resize();
            ShiftToRight(index);
            array[index] = item;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++) 
                if (array[i] == element) return true;
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            InOrOutOfRange(firstIndex);
            InOrOutOfRange(secondIndex);
            int firstElement = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = firstElement;
        }

        public void Reverse()
        {
            int[] copy = new int[Count];
            int counter = 0;
            for (int i = Count - 1; i >= 0; i--) 
                copy[counter++] = array[i];
            array = copy;
        }

        public override string ToString()
        {
            string text = string.Empty;
            for (int i = 0; i < Count; i++)
                text += $"{array[i]} ";
            return text;
        }


        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
                array[i] = array[i + 1];
            array[Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
                array[i] = array[i - 1];
            array[index] = default;
        }

        private void Resize()
        {
            int[] copy = new int[Count * 2];
            Array.Copy(array, copy, Count);
            array = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[array.Length / 2];
            Array.Copy(array, copy, Count);
            array = copy;
        }

        private void InOrOutOfRange(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException("Index is out of range.");
        }
    }
}
