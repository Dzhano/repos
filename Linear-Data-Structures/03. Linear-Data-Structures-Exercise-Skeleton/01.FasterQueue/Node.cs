namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node() { Next = null; }
        public Node(T item) : this() { Item = item; }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}