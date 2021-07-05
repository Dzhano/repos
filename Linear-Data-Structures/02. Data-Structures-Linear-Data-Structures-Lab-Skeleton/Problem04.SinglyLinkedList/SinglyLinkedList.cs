namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head; 

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = _head;
            _head = node;
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> node = new Node<T>(item);
            if (_head == null || Count == 0) _head = node;
            else
            {
                Node<T> current = this._head;
                while (current.Next != null) current = current.Next;
                current.Next = node;
            }
            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0 || _head == null) throw new InvalidOperationException();
            return _head.Element;
        }

        public T GetLast()
        {
            if (_head == null || Count == 0) throw new InvalidOperationException();

            Node<T> node = _head;
            while (true)
            {
                if (node.Next == null) return node.Element;
                node = node.Next;
            }
        }

        public T RemoveFirst()
        {
            if (_head == null || Count == 0) throw new InvalidOperationException();
            Node<T> node = _head;
            _head = _head.Next;
            Count--;
            return node.Element;
        }

        public T RemoveLast()
        {
            if (_head == null || Count == 0) throw new InvalidOperationException();

            Node<T> node = _head;
            if (_head != null && Count > 1)
            {
                for (int i = 0; i < Count - 2; i++) node = node.Next;
                T value = node.Next.Element;
                node.Next = null;
                Count--;
                return value;
            }
            else
            {
                T value = node.Element;
                node = null;
                _head = null;
                Count--;
                return value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = _head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}