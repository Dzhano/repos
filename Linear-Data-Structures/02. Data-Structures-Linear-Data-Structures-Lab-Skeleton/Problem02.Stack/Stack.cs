namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> node = _top;

            while (node != null)
            {
                if (node.Element.Equals(item)) return true;
                node = node.Next;
            }
            return false;
        }

        public T Peek()
        {
            if (_top == null || Count == 0) throw new InvalidOperationException();
            Node<T> node = _top;
            return node.Element;
        }

        public T Pop()
        {
            if (_top == null || Count == 0) throw new InvalidOperationException();
            Node<T> node = _top;
            _top = _top.Next;
            Count--;
            return node.Element;
        }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = _top;
            _top = node;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = _top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}