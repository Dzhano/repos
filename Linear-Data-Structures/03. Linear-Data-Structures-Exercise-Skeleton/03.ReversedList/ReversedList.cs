namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ChecksIndex(index);
                index = CalculateIndex(index);
                return _items[index];
            }
            set
            {
                ChecksIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == _items.Length) Resize();
            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (T thing in _items) if (thing.Equals(item)) return true;
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++) if (_items[i].Equals(item)) return CalculateIndex(i);
            return -1;
        }

        public void Insert(int index, T item)
        {
            ChecksIndex(index);
            index = CalculateIndex(index) + 1;
            ChecksIndex(index);
            if (Count == _items.Length) Resize();

            for (int i = Count; i >= index; i--)
                _items[i] = _items[i - 1];

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            bool exist = Contains(item);
            if (exist) 
            {
                int index = 0;
                for(int i = 0; i < Count; i++) if (_items[i].Equals(item)) index = i;

                ChecksIndex(index);
                for (int i = index; i < Count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _items[Count - 1] = default;
                Count--;
            }

            return exist;
        }

        public void RemoveAt(int index)
        {
            ChecksIndex(index);
            index = CalculateIndex(index);
            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--) yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ChecksIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
        }

        private int CalculateIndex(int index) => Count - 1 - index;

        private void Resize()
        {
            T[] newItems = new T[Count * 2];

            Array.Copy(_items, newItems, Count);

            _items = newItems;
        }
    }
}