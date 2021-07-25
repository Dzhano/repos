namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private bool IsRootDeleted;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
            IsRootDeleted = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();
            if (IsRootDeleted) return result;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                result.Add(subtree.Value);
                foreach (Tree<T> tree in subtree.Children)
                    queue.Enqueue(tree);
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();
            if (IsRootDeleted) return result;
            Dfs(this, result);
            return result;
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (Tree<T> child in tree.Children)
                Dfs(child, result);
            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> searchedNode = FindBfs(parentKey);
            CheckEmptyNode(searchedNode);
            searchedNode._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> searchedNode = FindBfs(nodeKey);
            CheckEmptyNode(searchedNode);

            foreach (Tree<T> child in searchedNode.Children) child.Parent = null;
            searchedNode._children.Clear();

            Tree<T> searchedParent = searchedNode.Parent;
            // If it is the root there is no parent.
            if (searchedParent == null) IsRootDeleted = true;
            else searchedParent._children.Remove(searchedNode);
            searchedNode.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBfs(firstKey);
            CheckEmptyNode(firstNode);
            Tree<T> secondNode = FindBfs(secondKey);
            CheckEmptyNode(secondNode);

            Tree<T> firstParent = firstNode.Parent;
            Tree<T> secondParent = secondNode.Parent;
            if (firstParent == null)
            {
                this.Value = secondNode.Value;
                this._children.Clear();
                foreach (Tree<T> child in secondNode._children)
                {
                    child.Parent = this;
                    _children.Add(child);
                }
            }
            else if (secondParent == null)
            {
                this.Value = firstNode.Value;
                this._children.Clear();
                foreach (Tree<T> child in firstNode._children)
                {
                    child.Parent = this;
                    _children.Add(child);
                }
            }
            else
            {
                firstNode.Parent = secondParent;
                secondNode.Parent = firstParent;

                int indexOfFirst = firstParent._children.IndexOf(firstNode);
                int indexOfSecond = secondParent._children.IndexOf(secondNode);

                firstParent._children[indexOfFirst] = secondNode;
                secondParent._children[indexOfSecond] = firstNode;
            }
        }



        private Tree<T> FindBfs(T parentKey)
        {
            Tree<T> searchedNode = null;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (subtree.Value.Equals(parentKey))
                {
                    searchedNode = subtree;
                    break;
                }

                foreach (Tree<T> tree in subtree.Children)
                    queue.Enqueue(tree);
            }

            return searchedNode;
        }

        private void CheckEmptyNode(Tree<T> searchedNode)
        {
            if (searchedNode == null)
                throw new ArgumentNullException();
        }
    }
}
