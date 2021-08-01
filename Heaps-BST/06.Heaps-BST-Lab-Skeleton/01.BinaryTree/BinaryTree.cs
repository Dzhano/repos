namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent) => AsString(this, indent);

        private string AsString(IAbstractBinaryTree<T> tree, int indent)
        {
            string output = new string(' ', indent) + tree.Value + "\r\n";

            if (tree.LeftChild != null) output += AsString(tree.LeftChild, indent + 2);
            if (tree.RightChild != null) output += AsString(tree.RightChild, indent + 2);

            return output;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();
            InOrderList(this, list);
            return list;
        }

        private void InOrderList(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> list)
        {
            if (tree.LeftChild != null) InOrderList(tree.LeftChild, list);

            list.Add(tree);

            if (tree.RightChild != null) InOrderList(tree.RightChild, list);
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();
            PostOrderList(this, list);
            return list;
        }

        private void PostOrderList(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> list)
        {
            if (tree.LeftChild != null) PostOrderList(tree.LeftChild, list);
            if (tree.RightChild != null) PostOrderList(tree.RightChild, list);

            list.Add(tree);
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();
            PreOrderList(this, list);
            return list;
        }

        private void PreOrderList(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> list)
        {
            list.Add(tree);

            if (tree.LeftChild != null) PreOrderList(tree.LeftChild, list);
            if (tree.RightChild != null) PreOrderList(tree.RightChild, list);
        }

        public void ForEachInOrder(Action<T> action) => ForEachAction(this, action);

        public void ForEachAction(IAbstractBinaryTree<T> tree, Action<T> action)
        {
            if (tree.LeftChild != null) ForEachAction(tree.LeftChild, action);

            action.Invoke(tree.Value);

            if (tree.RightChild != null) ForEachAction(tree.RightChild, action);
        }
    }
}
