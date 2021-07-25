namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children = new List<Tree<T>>();
            foreach (Tree<T> item in children)
            {
                item.AddParent(this);
                AddChild(item);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child) => _children.Add(child);

        public void AddParent(Tree<T> parent) => Parent = parent;

        public string GetAsString() => BuildTree(0).Trim();

        private string BuildTree(int space)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(new string(' ', space) + Key);
            foreach (Tree<T> child in _children) output.Append(child.BuildTree(space + 2));
            return output.ToString();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Dictionary<int, Tree<T>> dic = new Dictionary<int, Tree<T>>();
            GetDeepest(this, dic, 0);
            return dic.LastOrDefault().Value;
        }

        private void GetDeepest(Tree<T> tree, Dictionary<int, Tree<T>> dic, int place)
        {
            if (!dic.ContainsKey(place)) dic.Add(place, tree);
            foreach (Tree<T> child in tree.Children) GetDeepest(child, dic, place + 1);
        }

        public List<T> GetLeafKeys()
        {
            List<T> result = new List<T>();
            GetLeaf(this, result);
            return result;
        }

        private void GetLeaf(Tree<T> tree, List<T> result)
        {
            foreach (Tree<T> child in tree.Children)
                GetLeaf(child, result);
            if (tree._children.Count == 0) result.Add(tree.Key);
        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();
            GetMiddle(this, result);
            return result;
        }

        private void GetMiddle(Tree<T> tree, List<T> result)
        {
            foreach (Tree<T> child in tree.Children)
                GetMiddle(child, result);
            if (tree._children.Count > 0 && tree.Parent != null) result.Add(tree.Key);
        }

        public List<T> GetLongestPath()
        {
            Dictionary<int, Tree<T>> dic = new Dictionary<int, Tree<T>>();
            GetDeepest(this, dic, 0);

            Tree<T> longP = dic.LastOrDefault().Value;
            List<T> path = new List<T>();
            while (longP != null)
            {
                path.Add(longP.Key);
                longP = longP.Parent;
            }
            path.Reverse();

            return path;
        }


        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> dic = new List<List<T>>();
            GetSumPath(this, sum, dic);
            return dic;
        }

        private void GetSumPath(Tree<T> tree, int sum, List<List<T>> dic)
        {
            Tree<T> longP = tree;
            List<T> path = new List<T>();
            List<int> intPath = new List<int>();
            while (longP != null)
            {
                path.Add(longP.Key);
                intPath.Add(int.Parse(longP.Key.ToString()));
                longP = longP.Parent;
            }
            if (sum == intPath.Sum())
            {
                path.Reverse();
                dic.Add(path);
            }

            foreach (Tree<T> child in tree.Children) GetSumPath(child, sum, dic);
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> output = new List<Tree<T>>();
            GetSubTreesSumPath(this, output, sum);
            return output;
        }

        private int GetSubTreesSumPath(Tree<T> tree, List<Tree<T>> output, int sum)
        {
            int currentSum = Convert.ToInt32(tree.Key);

            foreach (var child in tree.Children) currentSum += GetSubTreesSumPath(child, output, sum);

            if (currentSum == sum) output.Add(tree);

            return currentSum;
        }
    }
}
