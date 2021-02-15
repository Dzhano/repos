using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList<T>
    {
        public ListNode<T> Head { get; set; }
        public ListNode<T> Tail { get; set; }
        private int count = 0;

        public void AddFirst(T element)
        {
            count++;
            ListNode<T> newHeadNode = new ListNode<T>(element);
            if (Head == null)
            {
                Head = newHeadNode;
                Tail = newHeadNode;
                return;
            }
            newHeadNode.NextNode = Head;
            Head.PreviousNode = newHeadNode;
            Head = newHeadNode;
        }
        public void AddLast(T element)
        {
            count++;
            ListNode<T> newTailNode = new ListNode<T>(element);
            if (Tail == null)
            {
                Head = newTailNode;
                Tail = newTailNode;
                return;
            }
            newTailNode.PreviousNode = Tail;
            Tail.NextNode = newTailNode;
            Tail = newTailNode;
        }
        public T RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("The list is empty");
            ListNode<T> headNode = Head;
            Head = Head.NextNode;
            if (this.Head != null) Head.PreviousNode = null;
            else Tail = null;
            count--;
            return headNode.Value;
        }
        public T RemoveLast()
        {
            if (Tail == null) throw new InvalidOperationException("The list is empty");
            ListNode<T> tailNode = Tail;
            Tail = Tail.PreviousNode;
            if (this.Tail != null) Tail.NextNode = null;
            else Head = null;
            count--;
            return tailNode.Value;
        }
        public void ForEach(Action<T> action)
        {
            ListNode<T> listNode = Head;
            for (int i = 0; i < count; i++)
            {
                action(listNode.Value);
                listNode = listNode.NextNode;
            }
        }
        public void ForEachFromTail(Action<T> action)
        {
            ListNode<T> listNode = Tail;
            for (int i = 0; i < count; i++)
            {
                action(listNode.Value);
                listNode = listNode.PreviousNode;
            }
        }
        public T[] ToArray()
        {
            int n = 0;
            T[] listNodeArray = new T[count];
            ForEach(listNode =>
            {
                listNodeArray[n++] = listNode;
            });
            return listNodeArray;
        }
    }
}
