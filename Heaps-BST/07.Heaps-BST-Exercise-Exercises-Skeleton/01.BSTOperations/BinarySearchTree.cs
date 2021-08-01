namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() => Count = 0;

        public BinarySearchTree(Node<T> root) : this() => Root = root;

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

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
            Count++;
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

        public void EachInOrder(Action<T> action) => Action(Root, action);

        private void Action(Node<T> root, Action<T> action)
        {
            if (root.LeftChild != null) Action(root.LeftChild, action);

            action.Invoke(root.Value);

            if (root.RightChild != null) Action(root.RightChild, action);
        }

        public List<T> Range(T lower, T upper)
        {
            List<T> range = new List<T>();
            Range(range, Root, lower, upper);
            return range;
        }

        private void Range(List<T> range, Node<T> node, T lower, T upper)
        {
            if (node.LeftChild != null) Range(range, node.LeftChild, lower, upper);

            if (node.Value.CompareTo(lower) >= 0 && node.Value.CompareTo(upper) <= 0)
            {
                range.Add(node.Value);
                
            }
            if (node.RightChild != null)
                Range(range, node.RightChild, lower, upper);
        }

        public void DeleteMin()
        {
            if (Count > 0)
            {
                if (Root.LeftChild == null) Root = Root.RightChild;
                else
                {
                    Node<T> node = Root;
                    while (true)
                    {
                        if (node.LeftChild.LeftChild == null)
                        {
                            if (node.LeftChild.RightChild != null)
                            {
                                node.LeftChild = node.LeftChild.RightChild;
                                node.LeftChild.RightChild = null;
                            }
                            else node.LeftChild = null;
                            break;
                        }
                        else node = node.LeftChild;
                    }
                }
                Count--;
            }
            else throw new InvalidOperationException();
        }

        public void DeleteMax()
        {
            if (Count > 0)
            {
                if (Root.RightChild == null) Root = Root.LeftChild;
                else
                {
                    Node<T> node = Root;
                    while (true)
                    {
                        if (node.RightChild.RightChild == null)
                        {
                            if (node.RightChild.LeftChild != null)
                            {
                                node.RightChild = node.RightChild.LeftChild;
                                node.RightChild.LeftChild = null;
                            }
                            else node.RightChild = null;
                            break;
                        }
                        else node = node.RightChild;
                    }
                }
                Count--;
            }
            else throw new InvalidOperationException();
        }

        public int GetRank(T element)
        {
            if (Count == 0) return 0;

            List<T> range = new List<T>();
            Rank(range, Root, element);
            return range.Count;
        }

        private void Rank(List<T> range, Node<T> node, T upper)
        {
            if (node.LeftChild != null) Rank(range, node.LeftChild, upper);

            if (node.Value.CompareTo(upper) < 0) range.Add(node.Value);

            if (node.RightChild != null)
                Rank(range, node.RightChild, upper);
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
