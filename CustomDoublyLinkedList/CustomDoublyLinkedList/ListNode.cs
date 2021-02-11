using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class ListNode
    {
        public ListNode(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public ListNode PreviousNode { get; set; }
        public ListNode NextNode { get; set; }
    }
}
