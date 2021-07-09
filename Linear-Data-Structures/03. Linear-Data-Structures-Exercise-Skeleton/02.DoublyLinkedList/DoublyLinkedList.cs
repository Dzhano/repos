namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Item = item,
                Next = this.head
            };
            if (Count == 0) tail = head = newNode;
            else
            {
                head.Previous = newNode;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Item = item,
                Previous = this.tail
            };
            if (Count == 0) head = tail = newNode;
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return this.head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            T headItem = this.head.Item;
            head = head.Next;
            this.Count--;

            return headItem;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            T tailItem = this.tail.Item;
            if (Count == 1) head = tail = null;
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            this.Count--;

            return tailItem;
        }



        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}