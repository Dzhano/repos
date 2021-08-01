namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() { }

        public BinarySearchTree(Node<T> root) : this()
        {
            Root = root;
            LeftChild = Root.LeftChild;
            RightChild = Root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            Node<T> result = null;
            result = FindElement(Root, element, result);

            if (result == null) return false;
            else return true;
        }

        public void Insert(T element)
        {
            if (Root == null) Root = new Node<T>(element, null, null);
            else Insert(Root, element);
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if (Contains(element))
            {
                Node<T> result = null;
                result = FindElement(Root, element, result);
                return new BinarySearchTree<T>(result);
            }
            else return null;
        }

        private Node<T> FindElement(Node<T> node, T element, Node<T> result)
        {
            if (element.CompareTo(node.Value) < 0)
            {
                if (node.LeftChild == null) result = null;
                else result = FindElement(node.LeftChild, element, result);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                if (node.RightChild == null) result = null;
                else result = FindElement(node.RightChild, element, result);
            }
            else result = node;
            return result;
        }

        private void Insert(Node<T> node, T element)
        {
            if (element.CompareTo(node.Value) < 0)
            {
                if (node.LeftChild == null)
                    node.LeftChild = new Node<T>(element, null, null);
                else Insert(node.LeftChild, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                if (node.RightChild == null)
                    node.RightChild = new Node<T>(element, null, null);
                else Insert(node.RightChild, element);
            }
        }
    }
}
