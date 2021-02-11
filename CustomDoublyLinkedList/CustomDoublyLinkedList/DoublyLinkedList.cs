using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }
        private int count = 0;

        public void AddFirst(int element)
        {
            count++;
            ListNode newHeadNode = new ListNode(element);
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
        public void AddLast(int element)
        {
            count++;
            ListNode newTailNode = new ListNode(element);
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
        public int RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("The list is empty");
            ListNode headNode = Head;
            Head = Head.NextNode;
            if (this.Head != null) Head.PreviousNode = null;
            else Tail = null;
            count--;
            return headNode.Value;
        }
        public int RemoveLast()
        {
            if (Tail == null) throw new InvalidOperationException("The list is empty");
            ListNode tailNode = Tail;
            Tail = Tail.PreviousNode;
            if (this.Tail != null) Tail.NextNode = null;
            else Head = null;
            count--;
            return tailNode.Value;
        }
        public void ForEach(Action<int> action)
        {
            ListNode listNode = Head;
            for (int i = 0; i < count; i++)
            {
                action(listNode.Value);
                listNode = listNode.NextNode;
            }
        }
        public void ForEachFromTail(Action<int> action)
        {
            ListNode listNode = Tail;
            for (int i = 0; i < count; i++)
            {
                action(listNode.Value);
                listNode = listNode.PreviousNode;
            }
        }
        public int[] ToArray()
        {
            int n = 0;
            int[] listNodeArray = new int[count];
            ForEach(listNode =>
            {
                listNodeArray[n++] = listNode;
            });
            return listNodeArray;
        }
    }
}
