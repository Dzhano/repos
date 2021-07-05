namespace Problem03.Queue
{
    public class Node<T>
    {
        public Node() { }

        public Node(T element) : this() => Element = element;

        public T Element { get; set; }

        public Node<T> Next { get; set; }
    }
}