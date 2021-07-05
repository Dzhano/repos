namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> node = _head;

            while (node != null)
            {
                if (node.Element.Equals(item)) return true;
                node = node.Next;
            }
            return false;
        }

        public T Dequeue()
        {
            if (Count == 0 || _head == null) throw new InvalidOperationException();
            Count--;
            Node<T> node = _head;
            _head = _head.Next;
            return node.Element;
        }

        public void Enqueue(T item)
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

        public T Peek()
        {
            if (Count == 0 || _head == null) throw new InvalidOperationException();
            return _head.Element;
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

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}