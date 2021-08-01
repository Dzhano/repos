namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;

            LeftChild = leftChild;
            if (LeftChild != null) LeftChild.Parent = this;

            RightChild = rightChild;
            if (RightChild != null) RightChild.Parent = this;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            IAbstractBinaryTree<T> firstTree = null;
            firstTree = FindElement(this, first, firstTree);
            List<T> firstAncestors = GetAncestors(firstTree);

            IAbstractBinaryTree<T> secondTree = null;
            secondTree = FindElement(this, second, secondTree);
            List<T> secondAncestors = GetAncestors(secondTree);

            return firstAncestors.Intersect(secondAncestors).ToList()[0];
        }

        private List<T> GetAncestors(IAbstractBinaryTree<T> tree)
        {
            List<T> ancestors = new List<T>();

            while (tree != null)
            {
                ancestors.Add(tree.Value);
                tree = tree.Parent;
            }

            return ancestors;
        }

        private IAbstractBinaryTree<T> FindElement(IAbstractBinaryTree<T> node, T element, IAbstractBinaryTree<T> result)
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
    }
}
