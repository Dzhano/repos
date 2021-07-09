namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public Node() 
        { 
            Previous = null; 
            Next = null; 
        }
        public Node(T item) : this() { Item = item; }

        public T Item { get; set; }

        public Node<T> Previous { get; set; }

        public Node<T> Next { get; set; }
    }
}