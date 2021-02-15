using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public ListNode<T> PreviousNode { get; set; }
        public ListNode<T> NextNode { get; set; }
    }
}
